using System;
using System.ComponentModel;
using System.Windows;

namespace systrader.Helpers
{
    /// <summary>
    /// A Base attached property to replace vanilla WPF attached property.
    /// </summary>
    public abstract class BaseAttachedProperty<Parent, Property> 
        where Parent : BaseAttachedProperty<Parent, Property>, new() 
    {
        #region Public Event
        /// <summary>
        /// Fires when the value changed.
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };
        #endregion

        #region Public Properties
        /// <summary>
        /// A singleton instance of our parent.
        /// </summary>
        public static Parent Instance { get; private set; } = new Parent();
        #endregion

        #region Attached property definitions
        /// <summary>
        /// The attached property for this class
        /// </summary>
        public static readonly DependencyProperty ValueProperty = 
            DependencyProperty.RegisterAttached("Value", typeof(Property), typeof(BaseAttachedProperty<Parent, Property>), 
                new UIPropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));

        /// <summary>
        /// The Callback event when the <see cref="ValueProperty"/> is changed
        /// </summary>
        /// <param name="d"> The UI element that had it's property changed. </param>
        /// <param name="e"> The arguments for the event. </param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Call the parent function
            Instance.OnValueChanged(d, e);

            // Call event listener
            Instance.ValueChanged(d, e);
        }

        /// <summary>
        /// Gets the attached property
        /// </summary>
        /// <param name="d">The element to get the property from </param>
        /// <returns></returns>
        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);

        /// <summary>
        /// Sets the attached property
        /// </summary>
        /// <param name="d">The element to get the property from </param>
        /// <param name="value"> The value to set the valeu to </param>
        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);
        #endregion

        #region Event Methods
        /// <summary>
        /// the method that is called when any attached property of this type is changed.
        /// </summary>
        /// <param name="sender"> The UI element that this element was changed for. </param>
        /// <param name="e"> The arguments for this event </param>
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }
        #endregion
    }
}
