<?php
	include "baglan.php";

	if($_POST["giris_yap"]){
		if(empty($_POST['kullanici_adi']) || empty($_POST['sifre'])){
			$_SESSION["bilgi"] = 1;
			header("Location: ../giris.php");
			exit();
		}
		$kullanicisor = $db->prepare("SELECT * FROM kayitlar where kul_adi=:kul_adi and password=:password");
		$kullanicisor->execute(array(
			'kul_adi' => $_POST['kullanici_adi'],
			'password' => $_POST['sifre']
		));

		$say = $kullanicisor->RowCount();
		if ($say == 1)
		{
			$kulcek = $kullanicisor->fetch(PDO::FETCH_ASSOC);
			$_SESSION['oyuncu_id'] = $kulcek['id'];
			
			header("Location: ../index.php");
			exit();
		}
		else
		{
			$_SESSION["bilgi"] = 2;
			header("Location: ../giris.php");
			exit();
		}
	}
	
	if($_POST["profil_guncelle"]){
		if(empty($_POST['kullanici_adi']) || empty($_POST['sifre']) || empty($_POST['sifre2'])){
			$_SESSION["bilgi"] = 1;
			header("Location: ../profil.php");
			exit();
		}
		
		$oyuncular=$db->prepare("SELECT * FROM kayitlar WHERE id=:id");
		$oyuncular->execute(array(
			'id' => $_SESSION["oyuncu_id"]
		));
		$oyuncu_bilgi = $oyuncular->fetch(PDO::FETCH_ASSOC);
		
		if($_POST['kullanici_adi'] != $oyuncu_bilgi["kul_adi"]){
			$kullanicisor = $db->prepare("SELECT * FROM kayitlar where kul_adi=:kul_adi");
			$kullanicisor->execute(array(
				'kul_adi' => $_POST['kullanici_adi']
			));
			$say = $kullanicisor->RowCount();
			if($say > 0){
				$_SESSION["bilgi"] = 2;
				header("Location: ../profil.php");
				exit();
			}
		}
		
		$kaydet = $db->prepare("UPDATE kayitlar set kul_adi=:kul_adi, password=:password where id=:id");
		$kaydet->execute(array(
			'kul_adi' => $_POST['kullanici_adi'],
			'password' => $_POST['sifre2'],
			'id' => $_SESSION["oyuncu_id"]
		));
		//print_r($kaydet->errorInfo());
		if($kaydet){
			$_SESSION["bilgi"] = 3;
			header("Location: ../profil.php");
			exit();
		}else{
			$_SESSION["bilgi"] = 4;
			header("Location: ../profil.php");
			exit();
		}
	}