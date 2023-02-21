<?php include "header.php"; ?>

		<div class="page-wrapper">
			<div class="page-content-wrapper">
				<div class="page-content">
					<div class="card">
						<div class="card-body">
							<div class="card-title">
								<h4 class="mb-0">Oyuncuların İstatistikleri</h4>
							</div>
							<hr/>
							<div class="table-responsive">
								<table id="example" class="table table-striped table-bordered" style="width:100%">
									<thead>
										<tr>
											<th>#</th>
											<th>Kullanıcı Adı</th>
											
											<th>Altın</th>
											<th>Elmas</th>
											<th>Puan</th>
										</tr>
									</thead>
									<tbody>
										<?php 
										$skor=$db->prepare("SELECT * FROM skorlar order by puan DESC");
										$skor->execute();
										$say = 0;
										while ($skor_veri=$skor->fetch(PDO::FETCH_ASSOC)){ 
											$say ++;
											$oyuncu=$db->prepare("SELECT * FROM kayitlar WHERE id=:id");
											$oyuncu->execute(array(
												'id' => $skor_veri["id"]
											));
											$oyuncu_veri = $oyuncu->fetch(PDO::FETCH_ASSOC);
										?>
										<tr>
											<td><?php echo $say; ?></td>
											<td><?php echo $oyuncu_veri["kul_adi"]; ?></td>
											
											<td><?php echo $skor_veri["altin_toplam"]; ?></td>
											<td><?php echo $skor_veri["elmas"]; ?></td>
											<td><?php echo $skor_veri["puan"]; ?></td>
										</tr>
										<?php } ?>
									</tbody>

								</table>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		
<?php include "footer.php"; ?>