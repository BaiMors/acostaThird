using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using Acosta;
using Acosta.Models;
using System.Collections.Generic;
using System.Linq;
using Acosta.ViewModels;

namespace Acosta.Views;

public partial class AddEmployeesView : UserControl
{
    SuharevaContext myConnection;
    Role role;
    
    public AddEmployeesView()
    {
        InitializeComponent();
    }
}