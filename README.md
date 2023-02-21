# The Path Of Death

# Unity 3D oyun Projesi

Bu çalışmamda amaç , Unity Oyun Geliştirme Platformu kullanılarak PC(Windows ) platformunda
çalışan bir sürekli koşmaya dayalı oyunu oluşturmak. Bu oyuna benzeyen Temple Run oyunun bir
temel olarak kullanılarak üstüne yeni seviyeler eklenmesini kolaylaştırmayı ve kod değişiklerinin
olabildiğince minimal seviyede olmasını amaçlamaktayım.Oyunda kullanıcı Giriş ve kayıt panellleri
yanında ayrıca Market ve Convert paneli ile satın alma işlemleri gerçekleşmiştir. Ayrıca bu oyunda
Farklı oyuncuların Skor, gibi nitelikleri bir web sayfasında sıralayıp kullanıma sunmayı planlıyorum.
# Kullanılan teknolojiler
- C#
- Php
- Web sayfası ara yüzü için HTML,CSS ,PHP dilleri kullanılmıştır.
# Logın-Create Sahnesi
Bu sahnede LOGIN ve CREATE adında iki ayrı panel oluşturdum . Burada oyuncuların gerekli
Giriş ve kayıt işlemleri gerçekleştirdim . veriler Mysql veritabanına anlık olarak kaydedip gerekli
sorgularla çekiyorum.
Oyuncu Giriş panelinide kullanıcı adını veya şifresini yanlış girdiği durumlarda , Create panelinde ise
kullanıcı adı şifre ve şifre tekrar durumlarını kontrol edip düzeli girildiğinde bile sorgu yapıp aynı
isimde kullanıcı adı olup olmadığını kontrol ettikten sonra aynı kullanıcı yoksa kaydediyr.
![alt text](https://github.com/HasanEren72/The_Path_Of_Death_-Oyun_projesi/blob/main/images/login.png)
<img src="https://github.com/HasanEren72/The_Path_Of_Death_-Oyun_projesi/login.png" alt="alt text" width="320" height="180">

# Market paneli
Oyunda kullanıcıların oyunu oynarken farklı karekterler ile oyuna devam etmelerini sağlamak
Ve gerekli bütün Altin elmas dönüşümlerini sağlamaları için Menu sahnesinde Market paneli yaptım
Bu panelde oyuncular karekter satın alabilir ,değiştirebilir .farklı karekterlerin hızı farklı niteliktedir.
Ayrıca karekter satın alma paneline ek olarak altın elmas dönüşümleri için Convert paneli de
oluşturdum.
Aşaıdaki görsellerde Market paneli Convert Paneli yer alıyor .

# Bölüm1-Bölüm2 Sahneleri
Oyununda 2 farklı bölüm yaptım Orman ve kış tema konulu olarak . adındanda anlaşıldığı üzere
orman sahnesi yani 1. Bölümde sahne tasarımı yol planı yeşillik orman tarzında yaptım .
1. Bölümde farklı olarak yağmur efekti ve sahneye uygun efekt ve nesneler kullandım.
Aynı şekilde 2. Bölümde de Kar efekti ve sahne uygun efekt ve nesneler kullandım .

