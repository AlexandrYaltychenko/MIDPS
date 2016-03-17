//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
#include <stdio.h>
#include "Unit1.h"
#include "dos.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;
struct time t;
struct date d;
TRect rect;
int nextY, next2Y, nextP;
bool first;
//---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button3Click(TObject *Sender)
{
Close();        
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button1Click(TObject *Sender)
{
Button1->Enabled = false;
Button2->Enabled = true;
Timer2->Enabled = true;
first = true;
rect.Left = 0;
rect.Right = 300;
rect.top = 0;
rect.Bottom = 300;
}
//---------------------------------------------------------------------------

void __fastcall TForm1::Button2Click(TObject *Sender)
{
Button1->Enabled = true;
Button2->Enabled = false;
Timer2->Enabled = false;
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
void cells(){

}
void __fastcall TForm1::Timer2Timer(TObject *Sender)
{
if (first){
nextP =  abs(rand()%100);
nextY = abs(rand()%100);
PaintBox1->Canvas->Pen->Color = clBlack;
for (int i =0; i<31; i++){
PaintBox1->Canvas->MoveTo(0,i*10);
PaintBox1->Canvas->LineTo(300,i*10);
}
for (int i =0; i<31; i++){
PaintBox1->Canvas->MoveTo(i*10,0);
PaintBox1->Canvas->LineTo(i*10,300);
}
first = false;
}
TRect rect2;
rect2.left = 0;
rect2.right = 300;
rect2.top = 0;
rect2.bottom = 300;
rect.left = -10;
rect.right = 290;
TRect rect3;
rect3.left = 290; rect3.right = 300; rect3.top = 0; rect3.bottom = 300;
PaintBox1->Canvas->FillRect(rect3);
PaintBox1->Canvas->MoveTo(290,0);
PaintBox1->Canvas->LineTo(290,300);
for (int i =0; i<31; i++){
PaintBox1->Canvas->MoveTo(290,i*10);
PaintBox1->Canvas->LineTo(300,i*10);
}
PaintBox1->Canvas->MoveTo(290,nextY+100);
PaintBox1->Canvas->Pen->Color = clRed;
nextY = next2Y;
PaintBox1->Canvas->LineTo(295,100+nextP);

PaintBox1->Canvas->LineTo(300,100+nextY);
PaintBox1->Canvas->CopyRect(rect,PaintBox1->Canvas, rect2);
PaintBox1->Canvas->Pen->Color = clBlack;

rect3.left = 290; rect3.right = 300; rect3.top = 0; rect3.bottom = 300;
PaintBox1->Canvas->FillRect(rect3);
PaintBox1->Canvas->MoveTo(290,0);
PaintBox1->Canvas->LineTo(290,300);

for (int i =0; i<31; i++){
PaintBox1->Canvas->MoveTo(290,i*10);
PaintBox1->Canvas->LineTo(300,i*10);
}

nextP =  abs(rand()%100);
PaintBox1->Canvas->Pen->Color = clRed;
next2Y = abs(rand()%100);
PaintBox1->Canvas->MoveTo(290,nextY+100);
PaintBox1->Canvas->LineTo(295,100+nextP);
PaintBox1->Canvas->LineTo(300,100+next2Y);
PaintBox1->Canvas->Pen->Color = clBlack;
PaintBox1->Canvas->MoveTo(300,0);
PaintBox1->Canvas->LineTo(300,300);
Panel2->Height = Panel1->Height*(nextP/100.0);
//PaintBox1->Canvas->FillRect(rect);
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
