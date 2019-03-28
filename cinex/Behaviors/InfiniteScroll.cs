using System;
using System.Collections;
using Xamarin.Forms;

namespace cinex.Behaviors
{
    public class InfiniteScroll : Behavior<ListView>
    {
        public static readonly BindableProperty LoadMoreCommandProperty = BindableProperty.Create("LoadMoreCommand", typeof(Command), typeof(InfiniteScroll), null);
        public Command LoadMoreCommand
        {
            get
            {
                return (Command)GetValue(LoadMoreCommandProperty);
            }
            set
            {
                SetValue(LoadMoreCommandProperty, value);
            }
        }

        public static readonly BindableProperty LoadMoreEnabledProperty = BindableProperty.Create("LoadMoreEnabled", typeof(bool), typeof(InfiniteScroll), null);
        public bool LoadMoreEnabled
        {
            get
            {
                return (bool)GetValue(LoadMoreEnabledProperty);
            }
            set
            {
                SetValue(LoadMoreEnabledProperty, value);
            }
        }

        public ListView AssociatedObject { get; set; }

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);
            AssociatedObject = bindable;

            bindable.BindingContextChanged += ListView_BindingContextChanged;
            bindable.ItemAppearing += Bindable_ItemAppearing;
        }

        private void ListView_BindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            BindingContext = AssociatedObject.BindingContext;
        }
        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.BindingContextChanged -= ListView_BindingContextChanged;
            bindable.ItemAppearing -= Bindable_ItemAppearing;
        }

        private void Bindable_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if(LoadMoreEnabled)
            {
                var items = AssociatedObject.ItemsSource as IList;
                if (items != null && e.Item == items[items.Count - 1])
                {
                    if (LoadMoreCommand != null && LoadMoreCommand.CanExecute(null))
                    {
                        LoadMoreCommand.Execute(null);
                    }
                }
            }
        }
    }
}
