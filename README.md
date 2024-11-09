# Mvc Proje Kampı

##  Genel Bakış

📘 Bu projede popüler sözlük uygulamalarının işleyişi baz alınarak bir Ekşi Sözlük benzeri site geliştirildi. Kullanıcıların sözlük başlıklarını görebileceği ve istediği başlığa bir entry girebileceği, kendisine diğer kullanıcılar tarafından gelen mesajları görebileceği bir kullanıcı paneli oluşturuldu. Admin tarafında başlıkların kategorilerini düzenleme, başlıkların ve içeriklerin yönetimi, mesajlaşma modülü gibi bir çok özellik eklendi. 

### 🎈 [Vitrin](#-vitrin-1)

🖼️ Projenin tanıtımı amacıyla bir Vitrin paneli tasarlandı. Proje hakkında bilgi verildi.

### 🎀 [Kullanıcı Paneli](#-kullanıcı-paneli-1)

👥 **Profilim:** Kullanıcı bilgilerini güncelleyebilir.

📑 **Başlıklarım:** Kullanıcının sözlüğe eklediği başlıklar listelenir. 
- 🔍 Eklediği başlığa diğer kullanıcıların yaptığı entry'leri İçerik butonu ile görebilir.
- ✏️ Düzenle ile başlık adını ve kategorisini değiştirebilir.

🗂️ **Tüm Başlıklar:** Sitede bulunan tüm başlıklar listelenir.
- 📜 Başlığın içeriğini görüntüleyebilir, başlığa yeni bir entry girebilir.

✉️ **Mesajlar:** Kullanıcı, diğer kullanıcılara yeni mesaj gönderebilir, gelen mesajlarını görüntüleyebilir, gönderdiği mesajları görebilir.
- 📄 Taslak Mesaj oluşturabilir, biçimlendirebilir ve dilerse tekrar iletebilir.
- 🗑️ Çöp Kutusu, mesajları tekli veya çoklu olarak silebilir, çöp kutusuna taşıyabilir. 

📝 **Yazılarım:** Başlıklara eklediği entry'leri burada görür.

🌐 **Siteye Git:** Siteye gidebilir, içerikleri görüntüleyebilir.

### 🌈 [Admin Paneli](#-admin-paneli-1)

📂 **Kategoriler:** Sitede bulunacak başlıkların eklendiği kategoriler listelenir.
- 🔄 Ekle/Sil/Güncelle işlemleri uygulanabilir ve kategoriye ait başlıklar listelenir.

📋 **Başlıklar:** Sitede bulunan başlıklar listelenir ve içerikleri görüntülenebilir.
- 🔄 Ekle/Sil/Güncelle işlemleri uygulanabilir. Aktif/Pasif Yap butonu ile başlığın görüntülenme durumu değiştirilebilir.

🖊️ **Yazılar:** Sitedeki tüm entry'ler listelenir ve arama filtresi uygulanabilir.

👥 **Yazarlar:** Siteye kayıt olan kullanıcılar listelenir ve yeni kullanıcı eklenebilir.

📊 **Grafikler:** Her kategorinin kaç başlığa sahip olduğu pie chart ile, başlıklara eklenen entry'lerin sayısı line chart ile görselleştirilir.

📈 **İstatistikler:** Siteye ait veriler listelenir.

ℹ️ **Hakkımda:** Site için hakkımda yazısı güncelleme ve ekleme özelliği.

📄 **Raporlar:** Sitedeki başlıkları Excel, CSV veya PDF olarak kaydetme özelliği.

💌 **İletişim & Mesajlar:** Admin, gelen mesajları görüntüleyebilir ve yeni mesajlar oluşturabilir.
- 🖊️ Yeni mesaj oluşturma, gelen mesajları görüntüleme, gönderdiği mesajları listeleme özellikleri.
- 📥 Taslak mesaj kaydedebilir ve Çöp Kutusuna mesaj gönderebilir.

🔐 **Yetkilendirmeler:** Admin yetkileri güncellenebilir ve yeni admin eklenebilir.
- 🚫 A yetkisine sahip admin, B yetkisine sahip adminin bilgilerini güncelleyemez. 'Yetkiniz yok' uyarısı alır.

🖼️ **Galeri:** Sitedeki görseller listelenir.

⚠️ **Hata Sayfası:** 404 hata sayfası eklendi.

💼 **Profil Kartı:** Dinamik olarak güncellenebilen bir yetenekler kartı eklendi.

### ✅ Veri Tabanı İlişkileri

![sql](https://github.com/user-attachments/assets/4cb29f96-8e7a-4565-976b-ecafec598415)

### 🚀 Kullanılan Teknolojiler

<table>
  <tr>
    <td>🎉 Asp.Net MVC ile hazırlanmıştır.</td>
    <td>📘 Repository Design Pattern kullanıldı.</td>
  </tr>
  <tr>
    <td>📚 Entity Framework kullanılmıştır.</td>
    <td>🔨 DbFirst yaklaşımı uygulanmıştır.</td>
  </tr>
  <tr>
    <td>🏢 N Katmanlı Mimari ile oluşturuldu.</td>
    <td>🏗️ CRUD işlemleri</td>
  </tr>
  <tr>
    <td>💾 MSSQL veri tabanı kullanılmıştır.</td>
    <td>📈 ChartJS ile chartlar oluşturuldu.</td>
  </tr>
  <tr>
    <td>📖 LINQ sorguları.</td>
    <td>⚙️ Partial Views, Paging ve Search işlemleri uygulandı.</td>
  </tr>
  <tr>
    <td>⚠️ Error Page Kullanımı</td>
    <td>📋 Dropdown ile veri listeleme</td>
  </tr>
  <tr>
    <td>📝 Data Annotations</td>
    <td>📂 Validation Rules uygulandı.</td>
  </tr>
  <tr>
    <td>🔑 Session Yönetimi</td>
    <td>🔐 Authentication ve Authorize işlemleri</td>
  </tr>
</table>


## Görseller

### 👀 Vitrin

![1](https://github.com/user-attachments/assets/91705854-7f4e-4d65-9fae-8a889fd15d3a)

### 🚪 Kullanıcı ve Admin Login Sayfaları

![writerLogin](https://github.com/user-attachments/assets/d8753522-d6d1-4e5c-8fee-53372a5f12b7)

![AdminLogin](https://github.com/user-attachments/assets/7a6cb445-c065-4fa2-a111-71ccb889c6e7)


### 💡 Kullanıcı Paneli

![yazar1](https://github.com/user-attachments/assets/95f3dff1-edc1-49c3-904e-c71691d4e4de)
![yazar2](https://github.com/user-attachments/assets/7ab90309-571a-4292-9575-7db04aa303bc)
![yazar3](https://github.com/user-attachments/assets/4cebc2ca-8977-42f2-8fe1-1d0ec5c33594)
![yazar4](https://github.com/user-attachments/assets/db91a0b5-a1d1-4846-85dd-e31bcfc0b149)
![yazar5](https://github.com/user-attachments/assets/fc44520e-cbe1-489e-a1bb-656c63f85003)
![yazar6](https://github.com/user-attachments/assets/57b12e48-fc4c-4fb9-a299-163cdaf21c4f)
![yazar7](https://github.com/user-attachments/assets/eb5dd4be-fd26-4023-a1e8-8c4c003bcaa5)
![yazar8](https://github.com/user-attachments/assets/066fed34-e614-4cdc-8ac9-ae8967b9a28f)
![yazar9](https://github.com/user-attachments/assets/8626d68e-4a6f-419d-95e5-295db2b72495)
![yazar10](https://github.com/user-attachments/assets/65114789-6888-474f-bd15-813020b162fd)
![yazar11](https://github.com/user-attachments/assets/629972ac-c69f-4ea0-9709-0047e6bdb283)
![yazar12](https://github.com/user-attachments/assets/d938c11c-f640-40e2-85c8-8a17755d9e25)
![yazar13](https://github.com/user-attachments/assets/c47c1f1f-0785-4e69-bd69-9f2d320cbd0c)
![yazar15](https://github.com/user-attachments/assets/992db9e4-a618-4018-a921-aba18d9452f7)

### 💻 Admin Paneli

![admin1](https://github.com/user-attachments/assets/ebaf8453-3d73-4946-9ade-49dba9e3ec5c)
![16](https://github.com/user-attachments/assets/49986b1e-98fc-4062-8579-95ba6bc6c748)
![17](https://github.com/user-attachments/assets/894aefcb-8a1d-40d1-a933-ad262b17d358)
![25](https://github.com/user-attachments/assets/5b7dfcca-bffe-426e-a273-6eb3a00f77f5)
![19](https://github.com/user-attachments/assets/f2274a45-471d-4c83-8c86-3193ab92fed3)
![26](https://github.com/user-attachments/assets/1268a01f-8dec-480e-8550-40ec529c54c7)
![20](https://github.com/user-attachments/assets/3a262812-35fa-42a8-bd24-4bd8d80c84d0)
![21](https://github.com/user-attachments/assets/ec5ac53b-ae1c-4957-8a38-d2ba83ed9c8b)
![22](https://github.com/user-attachments/assets/92abbdef-5120-4912-812e-179f0fa60e18)
![28](https://github.com/user-attachments/assets/828e9e86-5cdb-43be-97a6-ac79d4152119)
![23](https://github.com/user-attachments/assets/7151ca49-6fcd-4843-b483-3e8cb66efbb1)
![27](https://github.com/user-attachments/assets/7fe85fa6-b111-493d-92bb-d13471eb168a)
![24](https://github.com/user-attachments/assets/be1fc9ae-30e1-4adf-bbfb-5b7dc5c59d73)
![hata sayfası](https://github.com/user-attachments/assets/dacfdec8-d401-4739-9e58-ad97146b7a5d)
![yazar14](https://github.com/user-attachments/assets/3511afa9-22b3-438a-a843-c6ce71fd46ee)







