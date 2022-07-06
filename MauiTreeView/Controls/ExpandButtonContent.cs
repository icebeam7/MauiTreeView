﻿// 4
namespace MauiTreeView.Controls
{
    //set what icons shows for expanded/Collapsed/Leafe Nodes or on request node expand icon (when ShowExpandButtonIfEmpty true).
    public class ExpandButtonContent : ContentView
    {
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            var node = BindingContext as TreeViewNode;
            bool isLeafNode = (node.ChildrenList == null || node.ChildrenList.Count == 0);

            //empty nodes have no icon to expand unless showExpandButtonIfEmpty is et to true which will show the expand
            //icon can click and populated node on demand propably using the expand event.
            if ((isLeafNode) && !node.ShowExpandButtonIfEmpty)
            {
                Content = new ResourceImage
                {
                    Resource = isLeafNode ? "blank.png" : "folderopen.png",
                    HeightRequest = 16,
                    WidthRequest = 16
                };
            }
            else
            {
                Content = new ResourceImage
                {
                    Resource = node.IsExpanded ? "openglyph.png" : "collpsedglyph.png",
                    HeightRequest = 16,
                    WidthRequest = 16
                };
            }
        }
    }
}
