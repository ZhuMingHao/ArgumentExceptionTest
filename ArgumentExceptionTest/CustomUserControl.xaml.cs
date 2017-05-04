using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace ArgumentExceptionTest
{
    public enum InteractionMode
    {
        None,
        Initiative,
        Passive
    }

    public sealed partial class CustomUserControl : UserControl
    {
        public CustomUserControl()
        {
            this.InitializeComponent();
        }

        public InteractionMode ActiveInteractionMode
        {
            get { return (InteractionMode)GetValue(ActiveInteractionModeProperty); }
            set { SetValue(ActiveInteractionModeProperty, value); }
        }

        public static readonly DependencyProperty ActiveInteractionModeProperty =
            DependencyProperty.Register("ActiveInteractionMode", typeof(InteractionMode), typeof(CustomUserControl), new PropertyMetadata(InteractionMode.None, CanvasMapControl_InteractionModeChanged));

        private static void CanvasMapControl_InteractionModeChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if (args.OldValue != args.NewValue)
            {
                ((CustomUserControl)obj).InteractionModeInternal = (InteractionMode)args.NewValue;
            }
        }

        private InteractionMode _interactionModeInternal;

        private InteractionMode InteractionModeInternal
        {
            get
            {
                return _interactionModeInternal;
            }

            set
            {
                _interactionModeInternal = value;
                OnInteractionModeInternalChanged(value);
            }
        }

        private void OnInteractionModeInternalChanged(InteractionMode interactionMode)
        {
            System.Diagnostics.Debug.WriteLine($"InternalInteractionMode changed to {interactionMode}");
        }
    }
}