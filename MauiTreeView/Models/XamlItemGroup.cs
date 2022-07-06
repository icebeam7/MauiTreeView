//2
namespace MauiTreeView.Models
{
    [Serializable]
    public class XamlItemGroup
    {
        public List<XamlItemGroup> Children { get; } = new ();
        public List<XamlItem> XamlItems { get; } = new ();

        public string Name { get; set; }
        public int GroupId { get; set; }
    }
}
