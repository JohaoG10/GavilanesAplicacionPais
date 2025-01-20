using GavilanesAplicacionPais.Models;
using GavilanesAplicacionPais.Services;
using Microsoft.Maui.Controls;
using System.Collections.Generic;

namespace GavilanesAplicacionPais.Views;

public partial class VistaPaisBuscado : ContentPage
{
    private readonly ServicioBaseDeDatos _servicioBaseDeDatos;

    public VistaPaisBuscado()
    {
        InitializeComponent(); 
        _servicioBaseDeDatos = new ServicioBaseDeDatos();
        CargarPaises();
    }
    private async void CargarPaises()
    {
        var listaPaisesConsultados = await _servicioBaseDeDatos.ObtenerPaisesAsync();
        listViewPaises.ItemsSource = listaPaisesConsultados; 
    }
}