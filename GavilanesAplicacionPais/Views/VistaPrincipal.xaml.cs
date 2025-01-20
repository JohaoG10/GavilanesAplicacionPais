using GavilanesAplicacionPais.ViewModel;

namespace GavilanesAplicacionPais.Views;

public partial class VistaPrincipal : ContentPage
{
	public VistaPrincipal()
	{
		InitializeComponent();
		Binding context = new VistaPrincipalViewModel();
	}
}