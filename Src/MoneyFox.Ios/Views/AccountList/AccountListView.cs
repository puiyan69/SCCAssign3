using MoneyFox.Business.ViewModels;
using MoneyFox.Foundation.Resources;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;

namespace MoneyFox.Ios.Views.AccountList 
{
    // TODO: refactor for the new attributes with MvvmCross 5.0
    //[MvxChildPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, true)]
    public partial class AccountListView : MvxViewController<AccountListViewModel> 
	{
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			Title = Strings.AccountsLabel;

			ViewModel.LoadedCommand.Execute();

            var source = new MvxSimpleTableViewSource(AccountList, AccountTableCell.Key);
            this.CreateBinding(source).To<AccountListViewModel>(vm => vm.IncludedAccounts).Apply();
            this.CreateBinding(source).For(s => s.SelectionChangedCommand).To<AccountListViewModel>(vm => vm.OpenOverviewCommand).Apply();
            AccountList.RowHeight = 55;
            AccountList.Source = source;
            AccountList.ReloadData(); 

			var composeBtn = new UIBarButtonItem(UIBarButtonSystemItem.Compose, (o, args) => ViewModel.GoToAddAccountCommand.Execute());
			NavigationItem.SetRightBarButtonItem(composeBtn, true);
        }
    }
}