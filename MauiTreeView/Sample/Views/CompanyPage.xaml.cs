//S6 and S7
using MauiTreeView.Sample.Services;
using MauiTreeView.Sample.Helpers;

namespace MauiTreeView.Sample.Views;

public partial class CompanyPage : ContentPage
{
	DataService service;
    CompanyTreeViewBuilder companyTreeViewBuilder;

	public CompanyPage(DataService service, CompanyTreeViewBuilder companyTreeViewBuilder)
	{
		InitializeComponent();

		this.service = service;
        this.companyTreeViewBuilder = companyTreeViewBuilder;

		ProcessTreeView();
	}

	private void ProcessTreeView()
	{
        var xamlItemGroups = companyTreeViewBuilder.GroupData(service);
        var rootNodes = TheTreeView.ProcessXamlItemGroups(xamlItemGroups);
        TheTreeView.RootNodes = rootNodes;
    }
}