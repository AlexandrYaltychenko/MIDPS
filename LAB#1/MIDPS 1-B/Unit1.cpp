//---------------------------------------------------------------------------

#include <vcl.h>
#include <stdio.h>
#pragma hdrstop 
#include "Unit1.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
#include "dos.h"
TForm1 *Form1;
struct time t;
struct date d;
int min, sec, zec;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Timer1Timer(TObject *Sender)
{
char buf[20];
getdate(&d);
gettime(&t);
sprintf(buf,"%02d-%02d-%4d %02d:%02d:%02d",d.da_day,d.da_mon,d.da_year,
t.ti_hour,t.ti_min,t.ti_sec);
Edit1->Text=(AnsiString)buf;
}
//---------------------------------------------------------------------------
void __fastcall TForm1::Button1Click(TObject *Sender)
{
Timer2->Enabled = true;
Button2->Enabled = true;
Button1->Enabled = false;
Button3->Enabled = false;
}
//---------------------------------------------------------------------------
void __fastcall TForm1::Timer2Timer(TObject *Sender)
{
zec += 1;
if (zec >= 10){
zec = 0;
sec ++;
}
if (sec>=60){
sec = 0;
min ++;
}
char buf[20];
sprintf(buf,"%02d min %02d sec %d zec",min,sec, zec);
Edit2->Text=(AnsiString)buf;
}
//---------------------------------------------------------------------------
void __fastcall TForm1::Button2Click(TObject *Sender)
{
Timer2->Enabled = false;
Button1->Enabled = true;
Button3->Enabled = true;
Button2->Enabled = false;
}
//---------------------------------------------------------------------------
void __fastcall TForm1::Button3Click(TObject *Sender)
{
min = sec = zec = 0;
char buf[20];
sprintf(buf,"%02d min %02d sec %d zec",min,sec, zec);
Edit2->Text=(AnsiString)buf;
}
//---------------------------------------------------------------------------
void __fastcall TForm1::Button4Click(TObject *Sender)
{
Close();        
}
//---------------------------------------------------------------------------

void __fastcall TForm1::FormCreate(TObject *Sender)
{
char buf[20];
getdate(&d);
gettime(&t);
sprintf(buf,"%02d-%02d-%4d %02d:%02d:%02d",d.da_day,d.da_mon,d.da_year,
t.ti_hour,t.ti_min,t.ti_sec);
Edit1->Text=(AnsiString)buf;
}
//---------------------------------------------------------------------------

