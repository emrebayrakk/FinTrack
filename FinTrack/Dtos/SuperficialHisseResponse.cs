
using System;
using System.Text.Json.Serialization;
namespace FinTrack.Dtos
{

    public class SuperficialHisseResponse
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("hisseYuzeysel")]
        public HisseYuzeysel HisseYuzeysel { get; set; }

        [JsonPropertyName("stc_5_3")]
        public object Stc_5_3 { get; set; }

        [JsonPropertyName("rsI14")]
        public object RsI14 { get; set; }

        [JsonPropertyName("mov10")]
        public object Mov10 { get; set; }

        [JsonPropertyName("ccI14")]
        public object CcI14 { get; set; }
    }

    public class HisseYuzeysel
    {
        [JsonPropertyName("sembolid")]
        public int Sembolid { get; set; }

        [JsonPropertyName("sembol")]
        public string Sembol { get; set; }

        [JsonPropertyName("tarih")]
        public DateTime Tarih { get; set; }

        [JsonPropertyName("sektorid")]
        public int Sektorid { get; set; }

        [JsonPropertyName("alis")]
        public double Alis { get; set; }

        [JsonPropertyName("satis")]
        public double Satis { get; set; }

        [JsonPropertyName("acilis")]
        public double Acilis { get; set; }

        [JsonPropertyName("yuksek")]
        public double Yuksek { get; set; }

        [JsonPropertyName("yukseK1")]
        public double YukseK1 { get; set; }

        [JsonPropertyName("yukseK2")]
        public double YukseK2 { get; set; }

        [JsonPropertyName("dusuk")]
        public double Dusuk { get; set; }

        [JsonPropertyName("dusuK1")]
        public double DusuK1 { get; set; }

        [JsonPropertyName("dusuK2")]
        public double DusuK2 { get; set; }

        [JsonPropertyName("kapanis")]
        public double Kapanis { get; set; }

        [JsonPropertyName("kapaniS1")]
        public double KapaniS1 { get; set; }

        [JsonPropertyName("kapaniS2")]
        public double KapaniS2 { get; set; }

        [JsonPropertyName("hacimlot")]
        public double Hacimlot { get; set; }

        [JsonPropertyName("hacimloT1")]
        public double HacimloT1 { get; set; }

        [JsonPropertyName("hacimloT2")]
        public double HacimloT2 { get; set; }

        [JsonPropertyName("aort")]
        public double Aort { get; set; }

        [JsonPropertyName("aorT1")]
        public double AorT1 { get; set; }

        [JsonPropertyName("aorT2")]
        public double AorT2 { get; set; }

        [JsonPropertyName("hacimtldun")]
        public double Hacimtldun { get; set; }

        [JsonPropertyName("hacimyuzdedegisim")]
        public double Hacimyuzdedegisim { get; set; }

        [JsonPropertyName("hacimtl")]
        public double Hacimtl { get; set; }

        [JsonPropertyName("hacimtL1")]
        public double HacimtL1 { get; set; }

        [JsonPropertyName("hacimtL2")]
        public double HacimtL2 { get; set; }

        [JsonPropertyName("dunkukapanis")]
        public double Dunkukapanis { get; set; }

        [JsonPropertyName("oncekikapanis")]
        public double Oncekikapanis { get; set; }

        [JsonPropertyName("izafikapanis")]
        public double Izafikapanis { get; set; }

        [JsonPropertyName("tavan")]
        public double Tavan { get; set; }

        [JsonPropertyName("taban")]
        public double Taban { get; set; }

        [JsonPropertyName("yilyuksek")]
        public double Yilyuksek { get; set; }

        [JsonPropertyName("yildusuk")]
        public double Yildusuk { get; set; }

        [JsonPropertyName("ayyuksek")]
        public double Ayyuksek { get; set; }

        [JsonPropertyName("aydusuk")]
        public double Aydusuk { get; set; }

        [JsonPropertyName("haftayuksek")]
        public double Haftayuksek { get; set; }

        [JsonPropertyName("haftadusuk")]
        public double Haftadusuk { get; set; }

        [JsonPropertyName("oncekiyilkapanis")]
        public double Oncekiyilkapanis { get; set; }

        [JsonPropertyName("oncekiaykapanis")]
        public double Oncekiaykapanis { get; set; }

        [JsonPropertyName("oncekihaftakapanis")]
        public double Oncekihaftakapanis { get; set; }

        [JsonPropertyName("yilortalama")]
        public double Yilortalama { get; set; }

        [JsonPropertyName("ayortalama")]
        public double Ayortalama { get; set; }

        [JsonPropertyName("haftaortalama")]
        public double Haftaortalama { get; set; }

        [JsonPropertyName("yuzdedegisimS1")]
        public double YuzdedegisimS1 { get; set; }

        [JsonPropertyName("yuzdedegisimS2")]
        public double YuzdedegisimS2 { get; set; }

        [JsonPropertyName("yuzdedegisim")]
        public double Yuzdedegisim { get; set; }

        [JsonPropertyName("fiyatadimi")]
        public double Fiyatadimi { get; set; }

        [JsonPropertyName("kaykar")]
        public double Kaykar { get; set; }

        [JsonPropertyName("sermaye")]
        public double Sermaye { get; set; }

        [JsonPropertyName("saklamaor")]
        public double Saklamaor { get; set; }

        [JsonPropertyName("netkar")]
        public double Netkar { get; set; }

        [JsonPropertyName("net")]
        public double Net { get; set; }

        [JsonPropertyName("fiyatkaz")]
        public double Fiyatkaz { get; set; }

        [JsonPropertyName("piydeg")]
        public double Piydeg { get; set; }

        [JsonPropertyName("kapanisfark")]
        public object Kapanisfark { get; set; }

        [JsonPropertyName("donem")]
        public string Donem { get; set; }

        [JsonPropertyName("ozsermaye")]
        public double Ozsermaye { get; set; }

        [JsonPropertyName("beta")]
        public double Beta { get; set; }

        [JsonPropertyName("xU100AG")]
        public double XU100AG { get; set; }

        [JsonPropertyName("aciklama")]
        public string Aciklama { get; set; }
    }

}
