
using System.Diagnostics;

Stopwatch sw = Stopwatch.StartNew();
Console.WriteLine("[Dashboard] Memuat data halaman produk...");

// Memulai 3 Task secara independen & paralel
Task<string> getProductTask = FetchProductDataAsync();
Task<string> getPromoTask = FetchPromoDataAsync();
Task<string> getRecommendationTask = FetchRecommendationsAsync();

// Menunggu ketiga task selesai secara paralel
await Task.WhenAll(getProductTask, getPromoTask, getRecommendationTask);

sw.Stop();
Console.WriteLine($"-- > SELESAI dalam { sw.ElapsedMilliseconds}ms!");
Console.WriteLine($"Result 1: {getProductTask.Result}");
Console.WriteLine($"Result 2: {getPromoTask.Result}");
Console.WriteLine($"Result 3: {getRecommendationTask.Result}");

static async Task<string> FetchProductDataAsync()
{
    await Task.Delay(1000); // Simulasi I/O Query DB 1 detik
    return "Laptop Gaming RTX 4060 - Rp 18.000.000";
}

static async Task<string> FetchPromoDataAsync()
{
    await Task.Delay(800); // Simulasi API Call Promo 0.8 detik
    return "Diskon Flash Sale 10%";
}

static async Task<string> FetchRecommendationsAsync()
{
    await Task.Delay(1200); // Simulasi Service ML 1.2 detik
    return "Rekomendasi: Mouse Gaming, Cooling Pad";
}