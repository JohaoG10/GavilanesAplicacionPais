﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AplicacionPais.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using AplicacionPais.Services;
using GavilanesAplicacionPais.Services;

namespace GavilanesAplicacionPais.ViewModel
{
    public class VistaPrincipalViewModel : ObservableObject
    {
        private readonly ApiService _servicioApi;
        private readonly ServicioBaseDeDatos _servicioBaseDeDatos;

        public VistaPrincipalViewModel()
        {
            _servicioApi = new ApiService();
            _servicioBaseDeDatos = new ServicioBaseDeDatos();
            BuscarComando = new AsyncRelayCommand(BuscarPaisAsync);
            LimpiarComando = new RelayCommand(LimpiarCampos);
        }

        private string _nombrePais;
        public string NombrePais
        {
            get => _nombrePais;
            set => SetProperty(ref _nombrePais, value);
        }

        private string _region;
        public string Region
        {
            get => _region;
            set => SetProperty(ref _region, value);
        }

        private string _enlaceGoogleMaps;
        public string EnlaceGoogleMaps
        {
            get => _enlaceGoogleMaps;
            set => SetProperty(ref _enlaceGoogleMaps, value);
        }

        private string _nombreBD;
        public string NombreBD
        {
            get => _nombreBD;
            set => SetProperty(ref _nombreBD, value);
        }

        private string _mensajeError;
        public string MensajeError
        {
            get => _mensajeError;
            set => SetProperty(ref _mensajeError, value);
        }

        private bool _isErrorVisible;
        public bool IsErrorVisible
        {
            get => _isErrorVisible;
            set => SetProperty(ref _isErrorVisible, value);
        }

        public ICommand BuscarComando { get; }
        public ICommand LimpiarComando { get; }

        private async Task BuscarPaisAsync()
        {
            if (string.IsNullOrEmpty(NombrePais))
            {
                MensajeError = "Ingresa el nombre del país";
                IsErrorVisible = true;
                return;
            }

            var pais = await _servicioApi.ObtenerPaisPorNombreAsync(NombrePais);
            if (pais != null)
            {
          
                var nuevoPais = new Pais
                {
                    Nombre = pais.Nombre,
                    Region = pais.Region,
                    EnlaceGoogleMaps = pais.EnlaceGoogleMaps,
                    NombreBD = "JohaoG"  
                };

                await _servicioBaseDeDatos.GuardarPaisAsync(nuevoPais);

               
                NombrePais = pais.Nombre;
                Region = pais.Region;
                EnlaceGoogleMaps = pais.EnlaceGoogleMaps;
                NombreBD = "JohaoG";
                MensajeError = string.Empty;
                IsErrorVisible = false;
            }
            else
            {
                MensajeError = "EL pais no ha sido encontrado";
                IsErrorVisible = true;
            }
        }

        private void LimpiarCampos()
        {
            NombrePais = string.Empty;
            Region = string.Empty;
            EnlaceGoogleMaps = string.Empty;
            NombreBD = string.Empty;
            MensajeError = string.Empty;
            IsErrorVisible = false;
        }
    }
}