namespace models
{
    public class TaskTable
    {
        public TaskTable() {
            ColTexto = "";
            ColDt = "";
        }
        public int Id { get; set; }
        public string ColTexto { get; set; }
        public string ColDt { get; set; }
    }
}
