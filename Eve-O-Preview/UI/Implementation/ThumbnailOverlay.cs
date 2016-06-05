﻿using System;
using System.Windows.Forms;

namespace EveOPreview.UI
{
	public partial class ThumbnailOverlay : Form
	{
		private readonly Action<object, MouseEventArgs> _areaClickAction;

		public ThumbnailOverlay(Action<object, MouseEventArgs> areaClickAction)
		{
			this._areaClickAction = areaClickAction;
			InitializeComponent();
		}

		private void OverlayArea_Click(object sender, MouseEventArgs e)
		{
			this._areaClickAction(sender, e);
		}

		public void SetOverlayLabel(string label)
		{
			this.OverlayLabel.Text = label;
		}

		protected override CreateParams CreateParams
		{
			get
			{
				var Params = base.CreateParams;
				Params.ExStyle |= (int)DwmApiNativeMethods.WS_EX_TOOLWINDOW;
				return Params;
			}
		}
	}
}