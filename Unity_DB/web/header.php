<?php 

	include "kutuphane/baglan.php"; 
	if(isset($_SESSION["oyuncu_id"])){
		$oyuncular=$db->prepare("SELECT * FROM kayitlar WHERE id=:id");
		$oyuncular->execute(array(
			'id' => $_SESSION["oyuncu_id"]
		));
		$oyuncu_bilgi = $oyuncular->fetch(PDO::FETCH_ASSOC);
		
	}
?>
<!DOCTYPE html>
<html lang="tr">

<head>
	<!-- Required meta tags -->
	<meta charset="utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
	<title>The Path Of Death</title>
	
	<!--favicon-->
	<link rel="icon" href="assets/images/favicon-32x32.png" type="image/png" />
	<!--plugins-->
	<link href="assets/plugins/simplebar/css/simplebar.css" rel="stylesheet" />
	<!--Data Tables -->
	<link href="assets/plugins/datatable/css/dataTables.bootstrap4.min.css" rel="stylesheet" type="text/css">
	<link href="assets/plugins/datatable/css/buttons.bootstrap4.min.css" rel="stylesheet" type="text/css">
	<!--plugins-->
	<link href="assets/plugins/simplebar/css/simplebar.css" rel="stylesheet" />
	<link href="assets/plugins/perfect-scrollbar/css/perfect-scrollbar.css" rel="stylesheet" />
	<link href="assets/plugins/metismenu/css/metisMenu.min.css" rel="stylesheet" />
	<!-- loader-->
	<link href="assets/css/pace.min.css" rel="stylesheet" />
	<script src="assets/js/pace.min.js"></script>
	<!-- Bootstrap CSS -->
	<link rel="stylesheet" href="assets/css/bootstrap.min.css" />
	<!-- Icons CSS -->
	<link rel="stylesheet" href="assets/css/icons.css" />
	<!-- App CSS -->
	<link rel="stylesheet" href="assets/css/app.css" />
	
	
</head>
  
<body class="bg-theme bg-theme4">
	<!-- wrapper -->
	<div class="wrapper">
		<!--header-->
		<header class="top-header">
			<nav class="navbar navbar-expand">
				<div class="sidebar-header">
					<!--<div class="d-none d-lg-flex">
						<img src="assets/images/logo-icon.png" class="logo-icon-2" alt="" />
					</div>-->
					<div>
						<h4 class="d-none d-lg-flex logo-text">The Path Of Death</h4>
					</div>
					<a href="javascript:;" class="toggle-btn ml-lg-auto"> <i class="bx bx-menu"></i>
					</a>
				</div>
				<h1 id ="metin"><marquee behavior="vc" direction="">Welcome To The GAME </marquee></h1> 
			<style type ="text/css">
				#metin { color: chartreuse ;
					font-style: italic;
				}

				
					
			</style>
				<div class="right-topbar ml-auto">
					<ul class="navbar-nav">
						<?php if(isset($_SESSION["oyuncu_id"])){ ?>
						<li class="nav-item dropdown dropdown-user-profile">
							<a class="nav-link dropdown-toggle dropdown-toggle-nocaret" href="javascript:;" data-toggle="dropdown">
								<div class="media user-box align-items-center">
									<div class="media-body user-info">
										<p class="user-name mb-0"><?php echo $oyuncu_bilgi["kul_adi"]; ?></p>
										<p class="designattion mb-0">Oyuncu</p>
									</div>
									<img src="assets/images/profil.png" class="user-img" alt="user avatar">
								</div>
							</a>
							<div class="dropdown-menu dropdown-menu-right">	<a class="dropdown-item" href="profil.php"><i
										class="bx bx-user"></i><span>Profil</span></a>
								<div class="dropdown-divider mb-0"></div>	<a class="dropdown-item" href="cikis.php"><i
										class="bx bx-power-off"></i><span>Çıkış Yap</span></a>
							</div>
						</li>
						<?php } ?>
					</ul>
				</div>
			</nav>
		</header>
		<!--end header-->
		<!--navigation-->
		<div class="nav-container">
			<div class="mobile-topbar-header">
				<!--<div class="">
					<img src="assets/images/logo-icon.png" class="logo-icon-2" alt="" />
				</div>-->
				<div>
					<h4 class="logo-text">The Path Of Death</h4>
				</div>
				<a href="javascript:;" class="toggle-btn ml-auto"> <i class="bx bx-menu"></i>
				</a>
			</div>
			<nav class="topbar-nav">
				<ul class="metismenu" id="menu">
					<li class="col-md-3">
						<a href="index.php">
							<div class="parent-icon"><i class="bx bx-home-alt"></i>
							</div>
							<div class="menu-title">Anasayfa</div>
						</a>
					</li>
					<?php if(!isset($_SESSION["oyuncu_id"])){ ?>
					<li class="col-md-3">
						<a href="giris.php">
							<div class="parent-icon"><i class="bx bx-user"></i>
							</div>
							<div class="menu-title">Giriş Yap</div>
						</a>
					</li>
					<?php } ?>


				</ul>
			</nav>
		</div>