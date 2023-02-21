<?php
error_reporting(0);
                        //hostadı //adminadı//adminsifre //db
$baglanti = new mysqli("localhost","root","","unity_oyun");

// Check connection
if ($baglanti->connect_error) {
  echo"Connection failed: " . $baglanti->connect_error;
}


if($_POST['unity']=="kayitOlma"){

  $kullaniciAdi = $_POST['kullaniciAdi'];
  $sifre = $_POST['sifre'];
  $tarih = date('y-m-d');                 

  $sorgu = "insert into kayitlar(kul_adi,password,kayitTarihi) values ('$kullaniciAdi','$sifre','$tarih')";

  $sorgusonucu = $baglanti -> query($sorgu);

  if ($sorgusonucu)
  {
    echo "kayıt başarılı";
  }else
  {   //echo"lütfen farklı bir kullanıcı adı seçiniz";
    //if($baglanti->errno==1062)
    //{
        //echo"lütfen farklı bir kullanıcı adı seçiniz";
    //}else{
   // echo"başka hata";
   // }
  
  }
    

}



if($_POST['unity']=="girisYapma"){


  $kullaniciAdi = $_POST['kullaniciAdi'];
  $sifre = $_POST['sifre'];

  $sorgu = "select * from kayitlar where kul_adi='$kullaniciAdi' and password='$sifre' ";

  $sorgusonucu = $baglanti->query($sorgu);

  if($sorgusonucu-> num_rows>0){

    echo "giriş başarılı"; 
  }
  else{

    echo "giriş başarısız! kullanıcıadı veya şifre hatalı";

   }
}

if($_POST['unity']=="Puan_cekme"){


  $kullaniciAdi = $_POST['kullaniciAdi'];
  $sifre = $_POST['sifre'];

  $sorgu = "SELECT puan  FROM `skorlar` WHERE id=(select id from kayitlar where  kul_adi='$kullaniciAdi' and password ='$sifre' ) ";

  $sorgusonucu1 = $baglanti->query($sorgu);
  //$sorgusonucu = mysqli_query($baglanti , $sorgu)->fetch(PDO::FETCH_ASSOC);


  if($sorgusonucu1->num_rows>0 ){

  
    $srow = mysqli_fetch_assoc($sorgusonucu1);

    echo $srow["puan"];

  }
  else{

    echo "başarısız";

   }
}
if($_POST['unity']=="Altin_cekme"){


  $kullaniciAdi = $_POST['kullaniciAdi'];
  $sifre = $_POST['sifre'];

  $sorgu = "SELECT altin_toplam  FROM `skorlar` WHERE id=(select id from kayitlar where  kul_adi='$kullaniciAdi' and password ='$sifre' ) ";

  $sorgusonucu2 = $baglanti->query($sorgu);
  


  if($sorgusonucu2->num_rows>0 ){

   
    $srow = mysqli_fetch_assoc($sorgusonucu2);

    echo $srow["altin_toplam"];

  }
  else{

    echo "başarısız";

   }
}

if($_POST['unity']=="Elmas_cekme"){


  $kullaniciAdi = $_POST['kullaniciAdi'];
  $sifre = $_POST['sifre'];

  $sorgu = "SELECT elmas  FROM `skorlar` WHERE id=(select id from kayitlar where  kul_adi='$kullaniciAdi' and password ='$sifre' ) ";

  $sorgusonucu3 = $baglanti->query($sorgu);
  


  if($sorgusonucu3->num_rows>0 ){

   
    $srow = mysqli_fetch_assoc($sorgusonucu3);

    echo $srow["elmas"];

  }
  else{

    echo "başarısız";

   }
}
if($_POST['unity']=="ilk_skorlar_ekleme"){  // veritabanına güncellenmiş şekilde ekler
	$kullaniciAdi = $_POST['kullaniciAdi'];
	$sifre = $_POST['sifre'];

	$puan = 0;
	$toplamaltin =0;
	$top_elmas =0;


	//$sorgu = " INSERT INTO skorlar(id ,puan, altin_toplam,elmas) VALUES((select id=(select id from kayitlar where  kul_adi='$kullaniciAdi' and password ='$sifre' ) ),$puan, $toplamaltin, $top_elmas) ";
  $sorgu = "INSERT INTO skorlar(id ,puan, altin_toplam,elmas) 
  SELECT id, 0, 0, 0 FROM kayitlar WHERE kul_adi='$kullaniciAdi' and password ='$sifre' ";

	$sorgusonucu4 = $baglanti->query($sorgu);
	
	if($sorgusonucu4){
		echo "İLK skorlar kayit etme başarılı :";
	}
	else{
		echo "İLK skorlar kayit etme başarısız";
	}



}
if($_POST['unity']=="skorlar_ekleme"){  // veritabanına güncellenmiş şekilde ekler


  $kullaniciAdi = $_POST['kullaniciAdi'];
  $sifre = $_POST['sifre'];

  $puan = (int)$_POST['puan'];
  $toplamaltin = (int)$_POST['toplamAltin'];
  $top_elmas = (int)$_POST['top_elmas'];


  $sorgu = " UPDATE  skorlar SET puan=puan+$puan, altin_toplam=altin_toplam+$toplamaltin, elmas=elmas+$top_elmas WHERE id=(select id from kayitlar where  kul_adi='$kullaniciAdi' and password ='$sifre' ) ";

  $sorgusonucu4 = $baglanti->query($sorgu);
  


  if($sorgusonucu4){
    echo "skorlar kayit etme başarılı :";
  }
  else{
    echo "skorlar kayit etme başarısız";
  }
}


if($_POST['unity']=="AltinGuncelleme_ekleme"){  // veritabanına güncellenmiş şekilde ekler


  $kullaniciAdi = $_POST['kullaniciAdi'];
  $sifre = $_POST['sifre'];


  $toplamaltin =$_POST['DusecekAltinmiktari'];



  $sorgu = " UPDATE  skorlar SET  altin_toplam=altin_toplam-$toplamaltin WHERE id=(select id from kayitlar where  kul_adi='$kullaniciAdi' and password ='$sifre' ) ";

  $sorgusonucu5 = $baglanti->query($sorgu);
  


  if($sorgusonucu5){
    echo "alTİN Güncelleme Başarılı";
  }
  else{
    echo "alTİN Güncelleme başarısız";
  }
}




if($_POST['unity']=="ElmasGuncelleme_ekleme"){  // veritabanına güncellenmiş şekilde ekler


  $kullaniciAdi = $_POST['kullaniciAdi'];
  $sifre = $_POST['sifre'];


  $toplamElmas =$_POST['DusecekElmas_miktari'];



  $sorgu = " UPDATE  skorlar SET  elmas=elmas-$toplamElmas WHERE id=(select id from kayitlar where  kul_adi='$kullaniciAdi' and password ='$sifre' ) ";

  $sorgusonucu5 = $baglanti->query($sorgu);
  


  if($sorgusonucu5){
    echo "elmas Güncelleme Başarılı";
  }
  else{
    echo "elmas Güncelleme başarısız";
  }
}



if($_POST['unity']=="donusturme1_altin_elmas_guncelleme"){  // veritabanına güncellenmiş şekilde ekler


  $kullaniciAdi = $_POST['kullaniciAdi'];
  $sifre = $_POST['sifre'];


  $toplamElmas =$_POST['Dusecekelmasmiktari'];



  $sorgu = " UPDATE  skorlar SET  elmas=elmas-$toplamElmas,altin_toplam=altin_toplam+10000 WHERE id=(select id from kayitlar where  kul_adi='$kullaniciAdi' and password ='$sifre' ) ";

  $sorgusonucu5 = $baglanti->query($sorgu);
  


  if($sorgusonucu5){
    echo "Dönüştürme1 elmas-altin Güncelleme Başarılı";
  }
  else{
    echo "Dönüştürme1 elmas-altin Güncelleme Başarısız !";
  }
}



if($_POST['unity']=="donusturme2_altin_elmas_guncelleme"){  // veritabanına güncellenmiş şekilde ekler


  $kullaniciAdi = $_POST['kullaniciAdi'];
  $sifre = $_POST['sifre'];


  $toplamElmas =$_POST['Dusecekelmasmiktari'];



  $sorgu = " UPDATE  skorlar SET  elmas=elmas-$toplamElmas,altin_toplam=altin_toplam+1000 WHERE id=(select id from kayitlar where  kul_adi='$kullaniciAdi' and password ='$sifre' ) ";

  $sorgusonucu5 = $baglanti->query($sorgu);
  


  if($sorgusonucu5){
    echo "Dönüştürme2 elmas-altin Güncelleme Başarılı";
  }
  else{
    echo "Dönüştürme2 elmas-altin Güncelleme Başarısız !";
  }
}


if($_POST['unity']=="donusturme3_altin_elmas_guncelleme"){  // veritabanına güncellenmiş şekilde ekler


  $kullaniciAdi = $_POST['kullaniciAdi'];
  $sifre = $_POST['sifre'];


  $toplamaltinx =$_POST['Dusecek_Altin_miktari'];



  $sorgu = " UPDATE  skorlar SET  elmas=elmas+200,altin_toplam=altin_toplam-5000 WHERE id=(select id from kayitlar where  kul_adi='$kullaniciAdi' and password ='$sifre' ) ";

  $sorgusonucu5 = $baglanti->query($sorgu);
  


  if($sorgusonucu5){
    echo "Dönüştürme3 elmas-altin Güncelleme Başarılı";
  }
  else{
    echo "Dönüştürme3 elmas-altin Güncelleme Başarısız !";
  }
}

?>