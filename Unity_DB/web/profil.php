<?php 
	include "header.php"; 
	if(!isset($_SESSION["oyuncu_id"])){
		header("Location: ../giris.php");
		exit();
	}
?>

		<div class="page-wrapper">
			<div class="page-content-wrapper">
				<div class="page-content">
					<center>
					<div class="card radius-15 col-md-8">
						<div class="card-body">
							<div class="card-title">
								<h4 class="mb-0">Profil</h4>
							</div>
							<?php 
								if(isset($_SESSION["bilgi"])){
									switch($_SESSION["bilgi"]){
										case 1: $uyari = "danger"; $bilgi = "Boş alan bırakmayınız!"; break;
										case 2: $uyari = "danger"; $bilgi = "Kullanıcı adı sistemde zaten mevcut!"; break;
										case 3: $uyari = "success"; $bilgi = "Profil bilgileri güncellendi!"; break;
										case 4: $uyari = "danger"; $bilgi = "Profil bilgileri güncellenemedi, daha sonra tekrar deneyiniz!"; break;
									}
									
									echo '
									<div class="alert alert-'.$uyari.'" role="alert">
									  '.$bilgi.'
									</div>
									';
									
									unset($_SESSION["bilgi"]);
								}
							?>
							
							<hr/>
							<form action="kutuphane/islem.php" method="POST">
								<div class="form-group">
									<input name="kullanici_adi" class="form-control" type="text" placeholder="Kullanıcı Adı" value="<?php echo $oyuncu_bilgi["kul_adi"]; ?>" required>
								</div>
								
								<div class="form-group">
									<input name="sifre" class="form-control" type="password" placeholder="Yeni Şifre" required>
								</div>
								<div class="form-group">
									<input name="sifre2" class="form-control" type="password" placeholder="Yeni Şifre (Tekrar)" required>
								</div>
								
								
								<div class="form-group">
									<input name="profil_guncelle" class="form-control" type="submit" value="Güncelle">
								</div>
							</form>

						</div>
					</div>
					</center>
				</div>
			</div>
		</div>
		<br>
		<br>
		<br>
		<br>
		<br>
		<br>
		<br>
		<br>
<?php include "footer.php"; ?>