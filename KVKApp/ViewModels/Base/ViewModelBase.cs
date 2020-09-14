using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KVKApp.ViewModels.Base
{
    public abstract class ViewModelBase : MvvmHelpers.BaseViewModel
    {
        //protected readonly IDialogService DialogService;
        //protected readonly INavigationService NavigationService;

        public ViewModelBase()
        {
            //DialogService = Locator.Instance.Resolve<IDialogService>();
            //NavigationService = Locator.Instance.Resolve<INavigationService>();
        }

        public virtual Task InitializeAsync(object navigationData) => Task.FromResult(false);
    }
}
