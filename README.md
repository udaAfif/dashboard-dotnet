# dashboard-dotnet
Dashboard ini sudah menggunakan middleware, sehingga jika tidak ada token session dan jika ingin langsung redirect /Home maka tidak di izinkan, harus login terlebih dahulu. Berikut credential untuk login yang sudah terdaftar di database:
username : admin
password: admin123 (ROLE ADMIN)

username: standard
password: user123 (ROLE STANDARD)

Cara menjalankan aplikasi:
1. Download dahulu SDK https://dotnet.microsoft.com/en-us/download
2. Gunakan Visual Studio Code, lalu buka root project ini
3. Tuliskan perintah ini di terminal untuk migrations database, dotnet ef migrations add {NAMA MIGRATIONS TERSERAH}
4. Tuliskan perintah ini untuk update database, dotnet ef database update (dilakukan setalah ada perubahan di DB)
5. Jalankan perintah ini untuk menjalankan aplikasi, dotnet watch run
