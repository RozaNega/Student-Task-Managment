namespace Todo.Models
{
    public class Filters
    {
        public Filters(string filterstring)
        {
            FilterString = filterstring ?? "all-all-all";
            String[] filters = FilterString.Split('-');
            CategoryId = filters[0];
            Due = filters[1];
            StatusId = filters[2];

        }
        public string FilterString { get; }
        public string CategoryId { get; }
        public string Due { get; }
        public string StatusId { get; }
        public bool HasCategory => CategoryId.ToLower() != "all";
        public bool HasDue => Due.ToLower() != "all";
        public bool HasStatus => StatusId.ToLower() != "all";
        private static Dictionary<string, string> dueOptions = new()
        {
            { "future", "Future" },
            { "past", "Past" },
            { "today", " Today" },

        };
        public bool IsPast=> Due.ToLower() == "past";
        public bool IsFuture => Due.ToLower() == "future";
        public bool IsToday => Due.ToLower() == "today";

        public static dynamic DueFilterValues { get; internal set; }
        public static Dictionary<string, string> DueOptions { get => dueOptions; set => dueOptions = value; }
    }
}
