object Form1: TForm1
  Left = 192
  Top = 124
  Width = 469
  Height = 317
  Caption = 'MIDPS 1-A'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object Label1: TLabel
    Left = 160
    Top = 24
    Width = 238
    Height = 16
    Hint = 'title'
    Caption = 'Incrementare decrementare contor'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clRed
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
    ParentShowHint = False
    ShowHint = True
  end
  object Label2: TLabel
    Left = 272
    Top = 72
    Width = 150
    Height = 13
    Hint = 'info'
    Caption = 'i nu s-a schimbat in Edit1'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold, fsItalic]
    ParentFont = False
    ParentShowHint = False
    ShowHint = True
  end
  object Edit1: TEdit
    Left = 80
    Top = 168
    Width = 121
    Height = 21
    Hint = 'i value'
    ParentShowHint = False
    ShowHint = True
    TabOrder = 0
    Text = 'Edit1'
  end
  object Button1: TButton
    Left = 8
    Top = 128
    Width = 75
    Height = 25
    Hint = 'Increase i'
    Caption = 'UP'
    ParentShowHint = False
    ShowHint = True
    TabOrder = 1
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 8
    Top = 200
    Width = 75
    Height = 25
    Hint = 'Decrease i'
    Caption = 'DOWN'
    ParentShowHint = False
    ShowHint = True
    TabOrder = 2
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 280
    Top = 176
    Width = 75
    Height = 25
    Hint = 'Close the application'
    Caption = 'Exit'
    ParentShowHint = False
    ShowHint = True
    TabOrder = 3
    OnClick = Button3Click
  end
end
