using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TestFoonkie.Xamarin
{
    public partial class MainPage : ContentPage
    {
        #region VIEWS

        /// <summary>
        /// Define las vistas
        /// </summary>
        public enum ViewEnum
        {
            ActualizacionTramitePeticionGrid,
            ActualizacionTramitePeticionarioGrid,
            ActualizacionTramiteApoderadoGrid,
            ActualizacionTramiteAfectadoGrid
        }

        /// <summary>
        /// Define la vista Actual
        /// </summary>
        public ViewEnum CurrentView { get; set; }

        #endregion

        #region Grids

        /// <summary>
        /// Define las vistas
        /// </summary>
        public List<ViewEnum> Views { get; }

        #endregion

        #region GridsCarouselPosition

        /// <summary>
        /// Define la posición del CarouselView
        /// </summary>
        private int _GridsCarouselPosition;

        /// <summary>
        /// Obtiene o establece la posición del CarouselView
        /// </summary>
        public int GridsCarouselPosition
        {
            get
            {
                return _GridsCarouselPosition;
            }
            set
            {
                if (value > -1 && value < Views?.Count)
                    _GridsCarouselPosition = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        #endregion

        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();
            //Crea las vistas
            Views = new List<ViewEnum>()
            {
                ViewEnum.ActualizacionTramitePeticionGrid,
                ViewEnum.ActualizacionTramitePeticionarioGrid,
                ViewEnum.ActualizacionTramiteApoderadoGrid,
                ViewEnum.ActualizacionTramiteAfectadoGrid
            };
            OnPropertyChanged(nameof(Views));
        }

        /// <summary>
        /// Retrocede a la vista anterior
        /// </summary>
        /// <param name="sender">El control que hace el llamado</param>
        /// <param name="e">Los argumentos</param>
        private void Atras(object sender, EventArgs e)
        {
            GridsCarouselPosition--;
        }

        /// <summary>
        /// Navega a la siguiente vista
        /// </summary>
        /// <param name="sender">El control que hace el llamado</param>
        /// <param name="e">Los argumentos</param>
        private void Siguiente(object sender, EventArgs e)
        {
            GridsCarouselPosition++;
        }

        /// <summary>
        /// Cambia la posición de la vista
        /// </summary>
        /// <param name="sender">El control que ejecuta el evento</param>
        /// <param name="e">El argumento</param>
        private void Opcion_Seleccionada(object sender, EventArgs e)
        {
            GridsCarouselPosition = Convert.ToInt32((e as TappedEventArgs).Parameter);
        }
    }

    public class ActualizacionTramiteTemplateSelector : DataTemplateSelector
    {
        public DataTemplate A { get; set; }
        public DataTemplate B { get; set; }
        public DataTemplate C { get; set; }
        public DataTemplate D { get; set; }
        public DataTemplate E { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            MainPage.ViewEnum view = (MainPage.ViewEnum)item;

            if (view == MainPage.ViewEnum.ActualizacionTramitePeticionGrid)
                return A;

            if (view == MainPage.ViewEnum.ActualizacionTramitePeticionarioGrid)
                return B;

            if (view == MainPage.ViewEnum.ActualizacionTramiteApoderadoGrid)
                return C;

            if (view == MainPage.ViewEnum.ActualizacionTramiteAfectadoGrid)
                return D;

            return null;
        }
    }
}