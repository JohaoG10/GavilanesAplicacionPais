using GavilanesAplicacionPais.ViewModel;
using GavilanesAplicacionPais.Views;

namespace GavilanesAplicacionPais
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new VistaPrincipal();
            {
                BindingContext = new VistaPrincipalViewModel();
            }
    }
}
}