<?php include "header.php"; ?>

		<div class="page-wrapper">
			<div class="page-content-wrapper">
				<div class="page-content">
					<center>
					<div class="card radius-15 col-md-8">
						<div class="card-body">
							<div class="card-title">
								<h4 class="mb-0">Giriş Yap</h4>
							</div>
							<?php 
								if(isset($_SESSION["bilgi"])){
									switch($_SESSION["bilgi"]){
										case 1: $uyari = "danger"; $bilgi = "Boş alan bırakmayınız!"; break;
										case 2: $uyari = "danger"; $bilgi = "Kullanıcı adı veya şifre yanlış!"; break;
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
									<input name="kullanici_adi" class="form-control" type="text" placeholder="Kullanıcı Adı" required>
								</div>
								
								<div class="form-group">
									<input name="sifre" class="form-control" type="password" placeholder="Şifre" required>
								</div>
								
								
								<div class="form-group">
									<input name="giris_yap" class="form-control" type="submit" value="Giriş Yap">
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