namespace models
{
    public class TaskModifier
    {
        public TaskModifier() {
            ColTexto = "";
            ColDt = DateTime.Now;
        }
        public string ColTexto { get; set; }
        public DateTime ColDt { get; set; }
    }
}
