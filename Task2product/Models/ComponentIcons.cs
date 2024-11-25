namespace Task2product.Models
{
    public class ComponentIcons
    {
        public int Id { get; set; }
        public string? IconName { get; set; }
        public string? IconBgColour { get; set; }
        public String? IconTargetUrl  { get; set; }
        public string? IconClass { get; set; }

        public static List<ComponentIcons> AllIcons()
        {
            List<ComponentIcons> icons = new List<ComponentIcons>();
            icons.Add(new ComponentIcons { Id = 0, IconName = "Twitter", IconBgColour = "#000000", IconTargetUrl = "https://x.com/", IconClass = "fa fa-Twitter" });
            icons.Add(new ComponentIcons { Id = 1, IconName = "FaceBook", IconBgColour = "#000000", IconTargetUrl = "https://www.facebook.com/login/?next=https%3A%2F%2Fwww.facebook.com%2F", IconClass = "fa fa-FaceBook" });
            icons.Add(new ComponentIcons { Id = 2, IconName = "Google", IconBgColour = "#000000", IconTargetUrl = "https://www.google.com/", IconClass = "fa fa-Google" });
            icons.Add(new ComponentIcons { Id = 3, IconName = "YouTube", IconBgColour = "#000000", IconTargetUrl = "https://www.youtube.com/", IconClass = "fa fa-YouTube" });
            return icons;
        }
    }

}
