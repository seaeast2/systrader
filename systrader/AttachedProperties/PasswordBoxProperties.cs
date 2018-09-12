using System.Windows;
using System.Windows.Controls;
using systrader.Helpers;

namespace systrader
{
    /// <summary>
    /// The PasswordBoxProperties attached property for a <see cref="PasswordBox"/> 
    /// </summary>
    public class PasswordBoxProperties : BaseAttachedProperty<PasswordBoxProperties, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Get the caller
            var passwordBox = sender as PasswordBox;

            // Make sure it is password box
            if (passwordBox == null)
                return;

            // Remove any previous event
            passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;

            // If the caller set Monitor password to true...
            if ((bool)e.NewValue)
            {
                // Set default value
                HasTextProperty.SetValue(passwordBox);

                // Start listening out for password changed
                passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
            }
        }

        /// <summary>
        /// Fired when the password box is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            HasTextProperty.SetValue((PasswordBox)sender);
        }
    }

    /// <summary>
    /// The HasText Attached property for a <see cref="PasswordBox"/> 
    /// </summary>
    public class HasTextProperty : BaseAttachedProperty<HasTextProperty, bool>
    {
        /// <summary>
        /// Sets the HasText property based on if the caller <see cref="PasswordBox"/> has any text.
        /// </summary>
        /// <param name="sender"></param>
        public static void SetValue(DependencyObject sender)
        {
            SetValue(sender, ((PasswordBox)sender).SecurePassword.Length > 0);
        }
    }
}
