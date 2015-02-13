#pragma once

#include "VirtualChatRoom1.h"

namespace VirtualChatRoom {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for Form1
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		volatile static bool found;
		volatile static bool work;
		static String^ userName;
		Form1(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::TextBox^  txtUser;
	private: System::Windows::Forms::Button^  btnLogin;
	public: System::Windows::Forms::Label^  lblStatus;
	private: 


	protected: 

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->txtUser = (gcnew System::Windows::Forms::TextBox());
			this->btnLogin = (gcnew System::Windows::Forms::Button());
			this->lblStatus = (gcnew System::Windows::Forms::Label());
			this->SuspendLayout();
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(12, 9);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(63, 13);
			this->label1->TabIndex = 0;
			this->label1->Text = L"User Name:";
			// 
			// txtUser
			// 
			this->txtUser->Location = System::Drawing::Point(81, 6);
			this->txtUser->Name = L"txtUser";
			this->txtUser->Size = System::Drawing::Size(100, 20);
			this->txtUser->TabIndex = 1;
			this->txtUser->TextChanged += gcnew System::EventHandler(this, &Form1::txtUser_TextChanged);
			this->txtUser->KeyDown += gcnew System::Windows::Forms::KeyEventHandler(this, &Form1::txtUser_KeyDown);
			// 
			// btnLogin
			// 
			this->btnLogin->Location = System::Drawing::Point(15, 32);
			this->btnLogin->Name = L"btnLogin";
			this->btnLogin->Size = System::Drawing::Size(166, 23);
			this->btnLogin->TabIndex = 2;
			this->btnLogin->Text = L"Login";
			this->btnLogin->UseVisualStyleBackColor = true;
			this->btnLogin->Click += gcnew System::EventHandler(this, &Form1::btnLogin_Click);
			// 
			// lblStatus
			// 
			this->lblStatus->AutoSize = true;
			this->lblStatus->Location = System::Drawing::Point(15, 62);
			this->lblStatus->Name = L"lblStatus";
			this->lblStatus->Size = System::Drawing::Size(153, 13);
			this->lblStatus->TabIndex = 3;
			this->lblStatus->Text = L"Checking if username is valid...";
			this->lblStatus->Visible = false;
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(197, 86);
			this->Controls->Add(this->lblStatus);
			this->Controls->Add(this->btnLogin);
			this->Controls->Add(this->txtUser);
			this->Controls->Add(this->label1);
			this->MaximizeBox = false;
			this->Name = L"Form1";
			this->Text = L"Login";
			this->Load += gcnew System::EventHandler(this, &Form1::Form1_Load);
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion
	private: System::Void btnLogin_Click(System::Object^  sender, System::EventArgs^  e) {
				 found = false;
				 work = true;
				 UdpClient^ breaker = gcnew UdpClient();
				 IPEndPoint^ localHost = gcnew IPEndPoint(IPAddress::Loopback, 2100);
				 userName = txtUser->Text->Trim();

				 Thread^ nameChecker = gcnew Thread(gcnew ThreadStart(&checkName));

				 lblStatus->Visible = true;

				 nameChecker->Start(); // Start the thread to look if the user name is already in use
				 nameChecker->Join(5000); // Wait for the thread to finsh or for the time to be up

				 // Kill the thread
				 work = false;
				 Thread::Sleep(500);

				 // send a loop back msg to kill the blocking receiving function
				 while(nameChecker->IsAlive)
					 breaker->Send(Encoding::ASCII->GetBytes("00"), Encoding::ASCII->GetByteCount("00"), localHost);

				 breaker->Close();
				 lblStatus->Visible = false;

				 if(!String::IsNullOrEmpty(userName) && !found)
				 {
					 VirtualChatRoom^ frm = gcnew VirtualChatRoom();

					 frm->user = userName;
					 frm->Show();
					 this->Hide();
				 }
				 else
				 {
					 MessageBox::Show("Invalid User Name", "Error", MessageBoxButtons::OK, MessageBoxIcon::Error);
					 txtUser->Text = "";
					 txtUser->Focus();
				 }
			 }
private: System::Void txtUser_KeyDown(System::Object^  sender, System::Windows::Forms::KeyEventArgs^  e) {
			  if(e->KeyCode == Windows::Forms::Keys::Enter)
				 btnLogin->PerformClick();
		 }
private: System::Void txtUser_TextChanged(System::Object^  sender, System::EventArgs^  e) {
		 }
		 static void checkName()
		 {
			 IPEndPoint^ listen = gcnew IPEndPoint(IPAddress::Any, 2100);
			 UdpClient^ Listener = gcnew UdpClient(2100);

			 while(work)
			 {
				 try
				 {
					array<Byte>^ temp = Listener->Receive(listen);
					String^ pingMsg = Encoding::ASCII->GetString( temp );

					if(pingMsg->Substring(1)->ToLower() == userName->ToLower())
					{
						found = true;
						break;
					}
				 }
				 catch(Exception^ ex)
				 {
					 Windows::Forms::MessageBox::Show(ex->ToString());
				 }
			 }

			 Listener->Close();
		 }
private: System::Void Form1_Load(System::Object^  sender, System::EventArgs^  e) {
		 }
};
}

