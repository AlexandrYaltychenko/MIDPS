object Form1: TForm1
  Left = 192
  Top = 124
  Width = 646
  Height = 436
  Caption = 'MIDPS'
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
  object PaintBox1: TPaintBox
    Left = 320
    Top = 88
    Width = 305
    Height = 305
    Color = clBtnFace
    ParentColor = False
  end
  object Label1: TLabel
    Left = 256
    Top = 8
    Width = 90
    Height = 13
    Caption = 'Data si ore curente'
  end
  object Label2: TLabel
    Left = 256
    Top = 48
    Width = 282
    Height = 16
    Caption = 'Resurse grafice ale mediului C++ Builder'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -13
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Panel1: TPanel
    Left = 256
    Top = 88
    Width = 57
    Height = 300
    Color = clBackground
    TabOrder = 0
    object Panel2: TPanel
      Left = 1
      Top = 147
      Width = 55
      Height = 152
      Align = alBottom
      Color = clMedGray
      TabOrder = 0
    end
  end
  object Edit1: TEdit
    Left = 256
    Top = 24
    Width = 137
    Height = 21
    ReadOnly = True
    TabOrder = 1
    Text = 'Edit1'
  end
  object Button1: TButton
    Left = 88
    Top = 152
    Width = 75
    Height = 25
    Hint = 'Start process'
    Caption = '&START'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
    ParentShowHint = False
    ShowHint = True
    TabOrder = 2
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 88
    Top = 192
    Width = 75
    Height = 25
    Hint = 'Stop process'
    Caption = '&STOP'
    Enabled = False
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
    ParentShowHint = False
    ShowHint = True
    TabOrder = 3
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 88
    Top = 232
    Width = 75
    Height = 25
    Hint = 'Exit program'
    Caption = '&EXIT'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
    ParentShowHint = False
    ShowHint = True
    TabOrder = 4
    OnClick = Button3Click
  end
  object Timer1: TTimer
    OnTimer = Timer1Timer
    Left = 8
    Top = 8
  end
  object Timer2: TTimer
    Enabled = False
    Interval = 100
    OnTimer = Timer2Timer
    Left = 8
    Top = 80
  end
end
