using System.Drawing;
using CoreGraphics;
using UIKit;

namespace SimonGilbert.Blog.UI.Helpers
{
    public static class UIHelper
    {
        public static UIButton CreateButton(
            float xAxisPosition,
            float yAxisPosition,
            float height,
            UIButtonType buttonType,
            string buttonTitle,
            UIColor titleColour,
            UIColor backgroundColour,
            float cornerRadius,
            UIViewAutoresizing autoresizing)
        {
            var buttonFrame = CreateTextFieldFrame(xAxisPosition, yAxisPosition, height);

            var button = UIButton.FromType(buttonType);
            button.Frame = buttonFrame;
            button.SetTitle(buttonTitle, UIControlState.Normal);
            button.SetTitleColor(titleColour, UIControlState.Normal);
            button.BackgroundColor = backgroundColour;
            button.Layer.CornerRadius = cornerRadius;
            button.AutoresizingMask = autoresizing;

            return button;
        }

        public static UILabel CreateLabel(
            float xAxisPosition,
            float yAxisPosition,
            float height)
        {
            return CreateLabel(
                xAxisPosition,
                yAxisPosition,
                height,
                UIColor.White,
                UIColor.Black,
                UITextAlignment.Center);
        }

        public static UILabel CreateLabel(
            float xAxisPosition,
            float yAxisPosition,
            float height,
            UIColor backgroundColour)
        {
            return CreateLabel(
                xAxisPosition,
                yAxisPosition,
                height,
                backgroundColour,
                UIColor.Black,
                UITextAlignment.Center);
        }

        public static UILabel CreateLabel(
            float xAxisPosition,
            float yAxisPosition,
            float height,
            UIColor backgroundColour,
            UIColor textColor)
        {
            return CreateLabel(
                xAxisPosition,
                yAxisPosition,
                height,
                backgroundColour,
                textColor,
                UITextAlignment.Center);
        }

        public static UILabel CreateLabel(
            float xAxisPosition,
            float yAxisPosition,
            float height,
            UIColor backgroundColour,
            UIColor textColor,
            UITextAlignment textAlignment)
        {
            var labelFrame = CreateFrame(xAxisPosition, yAxisPosition, height);

            return new UILabel(labelFrame)
            {
                BackgroundColor = backgroundColour,
                TextColor = textColor,
                TextAlignment = textAlignment,
            };
        }

        public static UIView CreateViewWithLabel(
            float xAxisPosition,
            float yAxisPosition,
            float height,
            string text)
        {
            var label = CreateLabel(
                xAxisPosition,
                yAxisPosition,
                height,
                UIColor.White,
                UIColor.Black,
                UITextAlignment.Center);

            label.Text = text;

            var view = CreateView(xAxisPosition, yAxisPosition, height);

            view.AddSubview(label);

            return view;
        }

        public static UITextField CreateTextField(
            float xAxisPosition,
            float yAxisPosition,
            float height,
            string placeholder,
            UITextBorderStyle borderStyle,
            UIViewAutoresizing autoresizing)
        {
            var textFieldFrame = CreateTextFieldFrame(xAxisPosition, yAxisPosition, height);

            return new UITextField(textFieldFrame)
            {
                Placeholder = placeholder,
                BorderStyle = borderStyle,
                AutoresizingMask = autoresizing,
            };
        }

        public static UIView CreateView(float xAxisPosition, float yAxisPosition, float height)
        {
            var viewFrame = CreateFrame(
                xAxisPosition,
                yAxisPosition,
                height);

            return new UIView(viewFrame);
        }

        public static RectangleF CreateFrame(float xAxisPosition, float yAxisPosition, float height)
        {
            var screenWidth = (float)UIScreen.MainScreen.Bounds.Width;

            var margin = (xAxisPosition * 4);

            var width = screenWidth - margin;

            return new RectangleF(xAxisPosition, yAxisPosition, width, height);
        }

        public static CGRect CreateTextFieldFrame(float xAxisPosition, float yAxisPosition, float height)
        {
            var screenWidth = (float)UIScreen.MainScreen.Bounds.Width;

            var margin = (xAxisPosition * 2);

            var width = screenWidth - margin;

            return new CGRect(xAxisPosition, yAxisPosition, width, height);
        }
    }
}