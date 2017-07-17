﻿/*
 * Copyright (c) 2017 ETH Zürich, Educational Development and Technology (LET)
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using System.Windows;
using SafeExamBrowser.Contracts.UserInterface;

namespace SafeExamBrowser.UserInterface
{
	public partial class Taskbar : Window, ITaskbar
	{
		public Taskbar()
		{
			InitializeComponent();
		}

		public void AddButton(IApplicationButton button)
		{
			if (button is UIElement)
			{
				ApplicationStackPanel.Children.Add(button as UIElement);
			}
		}

		public void SetPosition(int x, int y)
		{
			Left = x;
			Top = y;
		}

		public void SetSize(int width, int height)
		{
			Width = width;
			Height = height;
		}

		private void ApplicationScrollViewer_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
		{
			var scrollAmount = 20;

			if (ApplicationScrollViewer.IsMouseOver)
			{
				if (e.Delta < 0)
				{
					if (ApplicationScrollViewer.HorizontalOffset + scrollAmount > 0)
					{
						ApplicationScrollViewer.ScrollToHorizontalOffset(ApplicationScrollViewer.HorizontalOffset + scrollAmount);
					}
					else
					{
						ApplicationScrollViewer.ScrollToLeftEnd();
					}
				}
				else
				{
					if (ApplicationScrollViewer.ExtentWidth > ApplicationScrollViewer.HorizontalOffset - scrollAmount)
					{
						ApplicationScrollViewer.ScrollToHorizontalOffset(ApplicationScrollViewer.HorizontalOffset - scrollAmount);
					}
					else
					{
						ApplicationScrollViewer.ScrollToRightEnd();
					}
				}
			}
		}
	}
}
