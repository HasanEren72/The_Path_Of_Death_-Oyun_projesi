# The Path Of Death

[google drive link of all files :](https://drive.google.com/drive/folders/1BdJABdXxC4m6eToXntPDNrySDSwgRNz9?usp=sharing)

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
# Oyunun ilerleyişi
Daha önceden Projenin amaç kısmında bahsettiğim gibi koşmaya dayalı stratejik Bir hayatta
kalma oyunu yaratmaktı amaç .
Bu kısımda projenin ilerleyişi nasıl olacak sorusuna cevap bulunacaktır.
Karekter belirsiz yollardan geçecektir . bu yollarda karşısına rastgele engeller ,tuzaklar çıkacaktır
Oyuncu bu engellerden başarılı bir şekilde kurtulup yoluna devam eder ise bir sonraki aşamaya
geçecekti. Fakat oyuncu bu engellere takılır ise başarısız olup ölecektir. Bu durumda Game-Over
sahnesine dönecektir . oyunu tekrar başlatınca aynı safaları tekrar yaşayacaktır.
Burada oyuncunun katettiği mesafe , skoru ,kullanıcı bilgileri DataBase ‘e kaydedilecektir.
Projenin 2. Aşamasında ise elde edilen bu veriler bir web sayfasına çekilecektir. Bu sayfa
oyuncuların Skorlarına göre sıralanıp efektif bir şekilde tasarlanacaktır.
Aşağıda Oyunun akış diyagramı yer almaktadır.

- Şekilde Oyunun akış diyagramı vardır
![diagram](https://github.com/HasanEren72/The_Path_Of_Death_-Oyun_projesi/blob/main/images/diagram.png)

# Logın-Create Sahnesi
Bu sahnede LOGIN ve CREATE adında iki ayrı panel oluşturdum . Burada oyuncuların gerekli
Giriş ve kayıt işlemleri gerçekleştirdim . veriler Mysql veritabanına anlık olarak kaydedip gerekli
sorgularla çekiyorum.
Oyuncu Giriş panelinide kullanıcı adını veya şifresini yanlış girdiği durumlarda , Create panelinde ise
kullanıcı adı şifre ve şifre tekrar durumlarını kontrol edip düzeli girildiğinde bile sorgu yapıp aynı
isimde kullanıcı adı olup olmadığını kontrol ettikten sonra aynı kullanıcı yoksa kaydediyr.
- Login paneli
![login](https://github.com/HasanEren72/The_Path_Of_Death_-Oyun_projesi/blob/main/images/login.png)

 - Create paneli
![create](https://github.com/HasanEren72/The_Path_Of_Death_-Oyun_projesi/blob/main/images/create.png)

# Market paneli
Oyunda kullanıcıların oyunu oynarken farklı karekterler ile oyuna devam etmelerini sağlamak
Ve gerekli bütün Altin elmas dönüşümlerini sağlamaları için Menu sahnesinde Market paneli yaptım
Bu panelde oyuncular karekter satın alabilir ,değiştirebilir .farklı karekterlerin hızı farklı niteliktedir.
Ayrıca karekter satın alma paneline ek olarak altın elmas dönüşümleri için Convert paneli de
oluşturdum.
Aşaıdaki görsellerde Market paneli Convert Paneli yer alıyor .

- Market paneli
![market](https://github.com/HasanEren72/The_Path_Of_Death_-Oyun_projesi/blob/main/images/menu.png)

# Bölüm1-Bölüm2 Sahneleri
Oyununda 2 farklı bölüm yaptım Orman ve kış tema konulu olarak . adındanda anlaşıldığı üzere
orman sahnesi yani 1. Bölümde sahne tasarımı yol planı yeşillik orman tarzında yaptım .
1. Bölümde farklı olarak yağmur efekti ve sahneye uygun efekt ve nesneler kullandım.
Aynı şekilde 2. Bölümde de Kar efekti ve sahne uygun efekt ve nesneler kullandım .
 
- Bölüm 1 sahnesi:
![bolum](https://github.com/HasanEren72/The_Path_Of_Death_-Oyun_projesi/blob/main/images/bolum1.png)
- Bölüm 2 sahnesi:
![bolum](https://github.com/HasanEren72/The_Path_Of_Death_-Oyun_projesi/blob/main/images/bolum2.png)

# Oyun Web Sayfası
Bu kısımda oyun web sayfası hakkında bilgi verecem . Oyunun kullanıcılar için kayıtlar ve skorlar
Oluşturup bu kullanıcıları çeşitli skorlara göre ( puan ,toplam Altın , toplam Elmas vb) web sayfasında
efektif olarak sıralamayı gerçekleştirdim.
Bu sayfada ayrıca kullanıcı girişi profil kısmında ise kullanıcı bilgilerini güncelleyecek sayfayıda yaptım.
kullanıcı arama , listeleme işlemlerini yaptım.
Web sayfası arayüzünde css ‘i efektif olarak kullandım . dil olarakta html ve php kullandım .
Veritabanı olarak da phpMysql veritabanını kullandım.
- Şekilde  oyunun web sayfası bulunuyor
![web](https://github.com/HasanEren72/The_Path_Of_Death_-Oyun_projesi/blob/main/images/Web.png)
