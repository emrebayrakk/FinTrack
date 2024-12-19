namespace FinTrack.Dtos
{
    public class AllHisseResponse
    {
        public string code { get; set; }
        public List<Datum> data { get; set; }
    }
    public class Datum
    {
        public int id { get; set; }
        public string kod { get; set; }
        public string ad { get; set; }
        public string tip { get; set; }
    }
}
