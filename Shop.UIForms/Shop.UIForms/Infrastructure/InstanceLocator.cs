
namespace Shop.UIForms.Infrastructure
{
    using Shop.UIForms.ViewModels;

    internal class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            Main = new MainViewModel();
        }


    }
}
