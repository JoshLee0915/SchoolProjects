#pragma once

#include "ActiveUsers.h"

using namespace System;
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Text;
using namespace System::Net;
using namespace System::Net::Sockets;
using namespace System::Threading;

namespace VirtualChatRoom {

	/// <summary>
	/// Summary for VirtualChatRoom
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>

	public ref class VirtualChatRoom : public System::Windows::Forms::Form
	{
	public:

		volatile int mode;
		volatile bool run;
		String^ user;
		UdpClient^ Sender;
		IPEndPoint^ PrivateChatIP;
		array<ActiveUsers^>^ onlineUsers;

		static const int BroadcastPort = 2100;
		static const int ChatPort = 2200;

	private: System::ComponentModel::BackgroundWorker^  Ping;
	private: System::ComponentModel::BackgroundWorker^  Receiver;


	private: System::ComponentModel::BackgroundWorker^  Listener;

	public: 
		VirtualChatRoom(void)
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
		~VirtualChatRoom()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::GroupBox^ groupBox1;
	private: System::Windows::Forms::TextBox^  txtMsg;
	protected: 

	private: System::Windows::Forms::RichTextBox^ rtbChat;
	private: System::Windows::Forms::GroupBox^  groupBox2;
	private: System::Windows::Forms::GroupBox^  gpbChatOptions;
	private: System::Windows::Forms::RadioButton^  rbtShowChat;
	private: System::Windows::Forms::ComboBox^  cmbMode;

	private: System::Windows::Forms::RadioButton^  rbtHideChat;
	private: System::Windows::Forms::GroupBox^  groupBox3;
	private: System::Windows::Forms::ListBox^  lstUsers;
	private: System::Windows::Forms::Button^  btnInvite;





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
			this->groupBox1 = (gcnew System::Windows::Forms::GroupBox());
			this->txtMsg = (gcnew System::Windows::Forms::TextBox());
			this->rtbChat = (gcnew System::Windows::Forms::RichTextBox());
			this->groupBox2 = (gcnew System::Windows::Forms::GroupBox());
			this->gpbChatOptions = (gcnew System::Windows::Forms::GroupBox());
			this->rbtHideChat = (gcnew System::Windows::Forms::RadioButton());
			this->rbtShowChat = (gcnew System::Windows::Forms::RadioButton());
			this->cmbMode = (gcnew System::Windows::Forms::ComboBox());
			this->groupBox3 = (gcnew System::Windows::Forms::GroupBox());
			this->btnInvite = (gcnew System::Windows::Forms::Button());
			this->lstUsers = (gcnew System::Windows::Forms::ListBox());
			this->Ping = (gcnew System::ComponentModel::BackgroundWorker());
			this->Listener = (gcnew System::ComponentModel::BackgroundWorker());
			this->Receiver = (gcnew System::ComponentModel::BackgroundWorker());
			this->groupBox1->SuspendLayout();
			this->groupBox2->SuspendLayout();
			this->gpbChatOptions->SuspendLayout();
			this->groupBox3->SuspendLayout();
			this->SuspendLayout();
			// 
			// groupBox1
			// 
			this->groupBox1->Controls->Add(this->txtMsg);
			this->groupBox1->Controls->Add(this->rtbChat);
			this->groupBox1->Location = System::Drawing::Point(12, 12);
			this->groupBox1->Name = L"groupBox1";
			this->groupBox1->Size = System::Drawing::Size(304, 357);
			this->groupBox1->TabIndex = 0;
			this->groupBox1->TabStop = false;
			this->groupBox1->Text = L"Chat";
			// 
			// txtMsg
			// 
			this->txtMsg->Location = System::Drawing::Point(7, 331);
			this->txtMsg->Name = L"txtMsg";
			this->txtMsg->Size = System::Drawing::Size(291, 20);
			this->txtMsg->TabIndex = 1;
			this->txtMsg->KeyDown += gcnew System::Windows::Forms::KeyEventHandler(this, &VirtualChatRoom::textBox1_KeyDown);
			// 
			// rtbChat
			// 
			this->rtbChat->BackColor = System::Drawing::Color::White;
			this->rtbChat->Cursor = System::Windows::Forms::Cursors::IBeam;
			this->rtbChat->Location = System::Drawing::Point(6, 19);
			this->rtbChat->Name = L"rtbChat";
			this->rtbChat->ReadOnly = true;
			this->rtbChat->Size = System::Drawing::Size(291, 306);
			this->rtbChat->TabIndex = 0;
			this->rtbChat->Text = L"";
			this->rtbChat->TextChanged += gcnew System::EventHandler(this, &VirtualChatRoom::rtbChat_TextChanged);
			// 
			// groupBox2
			// 
			this->groupBox2->Controls->Add(this->gpbChatOptions);
			this->groupBox2->Controls->Add(this->cmbMode);
			this->groupBox2->Location = System::Drawing::Point(322, 12);
			this->groupBox2->Name = L"groupBox2";
			this->groupBox2->Size = System::Drawing::Size(197, 117);
			this->groupBox2->TabIndex = 1;
			this->groupBox2->TabStop = false;
			this->groupBox2->Text = L"Chat Mode";
			// 
			// gpbChatOptions
			// 
			this->gpbChatOptions->Controls->Add(this->rbtHideChat);
			this->gpbChatOptions->Controls->Add(this->rbtShowChat);
			this->gpbChatOptions->Enabled = false;
			this->gpbChatOptions->Location = System::Drawing::Point(6, 46);
			this->gpbChatOptions->Name = L"gpbChatOptions";
			this->gpbChatOptions->Size = System::Drawing::Size(185, 65);
			this->gpbChatOptions->TabIndex = 1;
			this->gpbChatOptions->TabStop = false;
			this->gpbChatOptions->Text = L"Options";
			// 
			// rbtHideChat
			// 
			this->rbtHideChat->AutoSize = true;
			this->rbtHideChat->Location = System::Drawing::Point(37, 42);
			this->rbtHideChat->Name = L"rbtHideChat";
			this->rbtHideChat->Size = System::Drawing::Size(104, 17);
			this->rbtHideChat->TabIndex = 1;
			this->rbtHideChat->Text = L"Hide Public Chat";
			this->rbtHideChat->UseVisualStyleBackColor = true;
			// 
			// rbtShowChat
			// 
			this->rbtShowChat->AutoSize = true;
			this->rbtShowChat->Checked = true;
			this->rbtShowChat->Location = System::Drawing::Point(37, 19);
			this->rbtShowChat->Name = L"rbtShowChat";
			this->rbtShowChat->Size = System::Drawing::Size(109, 17);
			this->rbtShowChat->TabIndex = 0;
			this->rbtShowChat->TabStop = true;
			this->rbtShowChat->Text = L"Show Public Chat";
			this->rbtShowChat->UseVisualStyleBackColor = true;
			// 
			// cmbMode
			// 
			this->cmbMode->FormattingEnabled = true;
			this->cmbMode->Items->AddRange(gcnew cli::array< System::Object^  >(3) {L"Public", L"Private", L"Away"});
			this->cmbMode->Location = System::Drawing::Point(6, 19);
			this->cmbMode->Name = L"cmbMode";
			this->cmbMode->Size = System::Drawing::Size(185, 21);
			this->cmbMode->TabIndex = 0;
			this->cmbMode->SelectedIndexChanged += gcnew System::EventHandler(this, &VirtualChatRoom::cmbMode_SelectedIndexChanged);
			// 
			// groupBox3
			// 
			this->groupBox3->Controls->Add(this->btnInvite);
			this->groupBox3->Controls->Add(this->lstUsers);
			this->groupBox3->Location = System::Drawing::Point(322, 135);
			this->groupBox3->Name = L"groupBox3";
			this->groupBox3->Size = System::Drawing::Size(197, 234);
			this->groupBox3->TabIndex = 2;
			this->groupBox3->TabStop = false;
			this->groupBox3->Text = L"Online Users";
			// 
			// btnInvite
			// 
			this->btnInvite->Location = System::Drawing::Point(6, 206);
			this->btnInvite->Name = L"btnInvite";
			this->btnInvite->Size = System::Drawing::Size(185, 23);
			this->btnInvite->TabIndex = 1;
			this->btnInvite->Text = L"Invite To Chat";
			this->btnInvite->UseVisualStyleBackColor = true;
			this->btnInvite->Click += gcnew System::EventHandler(this, &VirtualChatRoom::btnInvite_Click);
			// 
			// lstUsers
			// 
			this->lstUsers->FormattingEnabled = true;
			this->lstUsers->Location = System::Drawing::Point(6, 19);
			this->lstUsers->Name = L"lstUsers";
			this->lstUsers->Size = System::Drawing::Size(185, 186);
			this->lstUsers->TabIndex = 0;
			// 
			// Ping
			// 
			this->Ping->DoWork += gcnew System::ComponentModel::DoWorkEventHandler(this, &VirtualChatRoom::Ping_DoWork);
			// 
			// Listener
			// 
			this->Listener->DoWork += gcnew System::ComponentModel::DoWorkEventHandler(this, &VirtualChatRoom::Listener_DoWork);
			// 
			// Receiver
			// 
			this->Receiver->DoWork += gcnew System::ComponentModel::DoWorkEventHandler(this, &VirtualChatRoom::Receiver_DoWork);
			// 
			// VirtualChatRoom
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(531, 381);
			this->Controls->Add(this->groupBox3);
			this->Controls->Add(this->groupBox2);
			this->Controls->Add(this->groupBox1);
			this->MaximizeBox = false;
			this->Name = L"VirtualChatRoom";
			this->Text = L"VirtualChatRoom";
			this->Load += gcnew System::EventHandler(this, &VirtualChatRoom::VirtualChatRoom_Load);
			this->FormClosing += gcnew System::Windows::Forms::FormClosingEventHandler(this, &VirtualChatRoom::VirtualChatRoom_FormClosing);
			this->groupBox1->ResumeLayout(false);
			this->groupBox1->PerformLayout();
			this->groupBox2->ResumeLayout(false);
			this->gpbChatOptions->ResumeLayout(false);
			this->gpbChatOptions->PerformLayout();
			this->groupBox3->ResumeLayout(false);
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void VirtualChatRoom_Load(System::Object^  sender, System::EventArgs^  e) {
				 // intalize the global varibles
				 mode = modes::publicChat;
				 run = true;
				 Sender = gcnew UdpClient();
				 onlineUsers = gcnew array<ActiveUsers^>(0);
				 PrivateChatIP = gcnew IPEndPoint(IPAddress::Broadcast,ChatPort);

				 // Allow sender to broadcast
				 Sender->EnableBroadcast = true;

				 // Set the chat box to allow threads to modify it directly
				 rtbChat->CheckForIllegalCrossThreadCalls = false;

				 // run the background threads
				 Ping->RunWorkerAsync();
				 Listener->RunWorkerAsync();
				 Receiver->RunWorkerAsync();

				 cmbMode->SelectedIndex = 0;
				 rtbChat->Text = String::Format("Logged on as {0}\n",user);
			 }
	private: System::Void VirtualChatRoom_FormClosing(System::Object^  sender, System::Windows::Forms::FormClosingEventArgs^  e) {
				 run = false;
				 String^ msg = String::Format("{0}{1}",(int)modes::disconnect,user);
				 array<Byte>^ temp = Encoding::ASCII->GetBytes(msg);

				 // Send a message to the client to break any blocking listeners
				 Sender->Send(Encoding::ASCII->GetBytes("99"), Encoding::ASCII->GetByteCount("99"), gcnew IPEndPoint(IPAddress::Loopback, ChatPort));
				 Sender->Send(Encoding::ASCII->GetBytes("99"), Encoding::ASCII->GetByteCount("99"), gcnew IPEndPoint(IPAddress::Loopback, BroadcastPort));
				 Thread::Sleep(100);
				 Sender->Send(temp, temp->Length, gcnew IPEndPoint(IPAddress::Broadcast, ChatPort));
				 Application::Exit();
			 }
	private: System::Void cmbMode_SelectedIndexChanged(System::Object^  sender, System::EventArgs^  e) {
				 // Enable the chat options when any other mode but public is set
				
				 if((mode = cmbMode->SelectedIndex) == 0)
				 {
					 gpbChatOptions->Enabled = false;

					 if(PrivateChatIP->Address != IPAddress::Broadcast)
					 {
						 String^ User = findUserName(PrivateChatIP->Address);
						 String^ DC_Msg = String::Format("{0}{1}", (int)modes::PrivateChateTerminated, user);

						 // Send to the person in private chat you are terminating private chat
						 Sender->Send(Encoding::ASCII->GetBytes(DC_Msg), Encoding::ASCII->GetByteCount(DC_Msg), PrivateChatIP);

						 PrivateChatIP = gcnew IPEndPoint(IPAddress::Broadcast,ChatPort); // reset the Private IP to terminate the private chat
						 rtbChat->AppendText(String::Format("NOTICE: You have terminated private chat with {0}",User));
					 }
				 }
				 else
					 gpbChatOptions->Enabled = true;
			 }
	private: System::Void Ping_DoWork(System::Object^  sender, System::ComponentModel::DoWorkEventArgs^  e) {
				UdpClient^ Broadcaster = gcnew UdpClient();
				try
				{
					String^ msg;
					IPEndPoint^ BrodcastIP = gcnew IPEndPoint(IPAddress::Broadcast,BroadcastPort);
					Broadcaster->EnableBroadcast = true;
					while(run)
					{
						// Function to broadcast the servers IP address
						msg = String::Format("{0}{1}",mode,user);
						array<Byte>^ Message = Encoding::ASCII->GetBytes(msg);
					
						// Broadcast ping every 10 milliseconds
						Broadcaster->Send(Message, Message->Length, BrodcastIP);
						Thread::Sleep(10);
					}
				}
				catch(Exception^ e)
				{
					rtbChat->AppendText("Ping Error:\n" + e->ToString());
				}
				finally
				{
					Broadcaster->Close();
				}
			 }
	private: System::Void Listener_DoWork(System::Object^  sender, System::ComponentModel::DoWorkEventArgs^  e) {
				 IPEndPoint^ listen = gcnew IPEndPoint(IPAddress::Any, BroadcastPort);
				 UdpClient^ Listener = gcnew UdpClient(BroadcastPort);

				 while (run)
				{
					bool found = false;
					try
					{
						array<Byte>^ temp = Listener->Receive(listen);
						String^ pingMsg = Encoding::ASCII->GetString( temp );

						if(onlineUsers->Length > 0)
						{
							for each(ActiveUsers^ fClient in onlineUsers)
							{
								if(fClient->IP == listen->Address->ToString())
								{
									found = true;
									update(listen->Address->ToString(),pingMsg);
									break;
								}
							}
						}
						
						if(found == false)
						{
							Array::Resize(onlineUsers, onlineUsers->Length+1);
							onlineUsers[onlineUsers->Length-1] = gcnew ActiveUsers();
							onlineUsers[onlineUsers->Length-1]->IP = listen->Address->ToString();
							onlineUsers[onlineUsers->Length-1]->User = pingMsg->Substring(1);
							int::TryParse(pingMsg->Substring(0,1),onlineUsers[onlineUsers->Length-1]->mode);
							updateUserList();
						}
					}
					catch(Exception^ e)
					{
						rtbChat->AppendText("Listener Error:\n" + e->ToString());
						break;
					}
				 }
				 Listener->Close();
			 }
	private: System::Void Receiver_DoWork(System::Object^  sender, System::ComponentModel::DoWorkEventArgs^  e) {
				 Windows::Forms::DialogResult AcceptDecline;
				 IPEndPoint^ listen = gcnew IPEndPoint(IPAddress::Any, ChatPort);
				 UdpClient^ Receiver = gcnew UdpClient(ChatPort);

				 while(run)
				 {
					 try
					 {
						 int receivedMode;
						 array<Byte>^ temp = Receiver->Receive(listen);
						 String^ Msg = Encoding::ASCII->GetString(temp);

						 int::TryParse(Msg->Substring(0,1),receivedMode);

						 // Check for public chat private chat Invites and invite responses
						 switch(receivedMode)
						 {
						 case modes::publicChat:
							 if(rbtShowChat->Checked || cmbMode->SelectedIndex == 0)
								 rtbChat->AppendText(Msg->Substring(1));
							 break;
						 case modes::privateChat:
							 rtbChat->AppendText(Msg->Substring(1));
							 break;
						 case modes::Invite:
							 AcceptDecline = MessageBox::Show(String::Format("{0} has invited your to a private chat\nDo you accept the invite?",Msg->Substring(1)), "Private Chat Invite", MessageBoxButtons::YesNo, MessageBoxIcon::Question);

							 if(AcceptDecline == ::DialogResult::Yes)
							 {
								 // if you are changing private chats from one user to another
								 if(PrivateChatIP->Address != IPAddress::Broadcast)
								 {
									 String^ DC_Msg = String::Format("{0}{1}", (int)modes::disconnect, user);

									 Receiver->Send(Encoding::ASCII->GetBytes(DC_Msg), Encoding::ASCII->GetByteCount(DC_Msg), PrivateChatIP);
								 }

								 String^ response = String::Format("{0}{1}", (int)modes::Accept, user);
								 array<Byte>^ tmpResponse = Encoding::ASCII->GetBytes(response);
								 PrivateChatIP = gcnew IPEndPoint(listen->Address,ChatPort);

								 Receiver->Send(tmpResponse, tmpResponse->Length, PrivateChatIP);

								 cmbMode->SelectedIndex = modes::privateChat;

								 rtbChat->AppendText(String::Format("You are now in a private chat with {0}\n",Msg->Substring(1)));
							 }
							 else
							 {
								 String^ response = String::Format("{0}{1}", (int)modes::Decline, user);
								 array<Byte>^ tmpResponse = Encoding::ASCII->GetBytes(response);

								 Receiver->Send(tmpResponse, tmpResponse->Length, gcnew IPEndPoint(listen->Address,ChatPort));

								 rtbChat->AppendText(String::Format("You have declined to private chat with {0}\n",Msg->Substring(1)));
							 }
							 break;
						 case modes::Decline:
							 rtbChat->AppendText(String::Format("NOTICE: {0} has declined your invite\n",Msg->Substring(1)));
							 break;
						 case modes::Accept:
							 cmbMode->SelectedIndex = modes::privateChat;
							 PrivateChatIP = gcnew IPEndPoint(listen->Address,ChatPort);
							 rtbChat->AppendText(String::Format("NOTICE: {0} has accepted your invite\n",Msg->Substring(1)));
							 break;
						 case modes::PrivateChateTerminated:
							 PrivateChatIP = gcnew IPEndPoint(IPAddress::Broadcast,ChatPort);
							 cmbMode->SelectedIndex = modes::publicChat;
							 rtbChat->AppendText(String::Format("NOTICE: {0} has terminated your private chat\n",Msg->Substring(1)));
							 break;
						 case modes::disconnect:
							 int index = findIndex(listen->Address);

							 if(index > -1)
							 {
								 Array::Clear(onlineUsers, index, 1);
								 Array::Resize(onlineUsers, onlineUsers->Length-1);
								 rtbChat->AppendText(String::Format("NOTICE: {0} has left the chat\n", Msg->Substring(1)));
								 updateUserList();
							 }
							 break;
						 }
					 }
					 catch(Exception^ e)
					 {
						rtbChat->AppendText("Receiver Error:\n" + e->ToString());
						break;
					 }
				 }
				 Receiver->Close();
			 }

	private: System::Void textBox1_KeyDown(System::Object^  sender, System::Windows::Forms::KeyEventArgs^  e) {
			 if(e->KeyCode == Windows::Forms::Keys::Enter)
			 {
				 String^ msg = String::Format("{0}{1}: {2}\n",mode,user,txtMsg->Text);
				 array<Byte>^ temp = Encoding::ASCII->GetBytes(msg);
				 try
				 {
					 if(mode == modes::publicChat)
						 Sender->Send(temp, temp->Length, gcnew IPEndPoint(IPAddress::Broadcast,ChatPort));
					 
					 else if(mode == modes::privateChat)
					 {
						 // echo the msg of PrivateIP is not set to the broadcast addr
						 if(PrivateChatIP->Address != IPAddress::Broadcast)
							 rtbChat->AppendText(msg->Substring(1));
						 Sender->Send(temp, temp->Length, PrivateChatIP);
					 }
				 }
				 catch(Exception^ e)
				 {
					rtbChat->AppendText("Sender Error:\n" + e->ToString());
				 }
				 txtMsg->Text = "";
			 }
		 }
	private: System::Void btnInvite_Click(System::Object^  sender, System::EventArgs^  e) {
				 if(lstUsers->SelectedIndex >= 0)
				 {
					 if(onlineUsers[lstUsers->SelectedIndex]->User != user)
					 {
						 String^ msg = String::Format("{0}{1}", (int)modes::Invite, user);
						 IPEndPoint^ Receiver = gcnew IPEndPoint(IPAddress::Parse(onlineUsers[lstUsers->SelectedIndex]->IP),ChatPort);
						 
						 try
						 {
							 // send the request for private chat
							  array<Byte>^ temp = Encoding::ASCII->GetBytes(msg);
							  Sender->Send(temp, temp->Length, Receiver);

							  // notify the user the invite was sent
							  rtbChat->AppendText("Invite sent to " + onlineUsers[lstUsers->SelectedIndex]->User + "\n");
						 }
						 catch(Exception^ e)
						 {
							rtbChat->AppendText("Invite Error:\n" + e->ToString());
						 }
					 }
					 else
						  rtbChat->AppendText("ERROR: Can not invite self to private chat\n");
				 }
				 else
					 rtbChat->AppendText("ERROR: No active user selected\n");
			 }
			 void update(String^ ip, String^ msg)
			 {
				 for(int index = 0; index < onlineUsers->Length; index++)
				 {
					 if(onlineUsers[index]->IP == ip)
					 {
						 int NewMode;
						 int::TryParse(msg->Substring(0,1),NewMode);
//						 onlineUsers[index]->User = msg->Substring(1);
						 if(onlineUsers[index]->mode != NewMode)
						 {
							 onlineUsers[index]->mode = NewMode;
							 updateUserList();
						 }
						 break;
					 }
				 }
			 }

			 void updateUserList()
				{
					 int index = lstUsers->SelectedIndex;
					 lstUsers->BeginUpdate();
					 lstUsers->Items->Clear();
					 
					 for each(ActiveUsers^ user in onlineUsers)
					 {
						 lstUsers->Items->Add(String::Format("{0}    {1}    {2}", user->User, user->mode, user->IP));
					 }

					 int size = lstUsers->Items->Count;

					 if(size > index)
						 lstUsers->SelectedIndex = index;
					 else
						 lstUsers->SelectedIndex = -1;

					 lstUsers->EndUpdate();
				 }
			 String^ findUserName(IPAddress^ addr)
			 {
				String^ user = "UNKNOWN";

				for each(ActiveUsers^ activeUser in onlineUsers)
				{
					if(activeUser->IP == addr->ToString())
					{
						user = activeUser->User;
						break;
					}
				}
				return user;
			 }
			 int findIndex(IPAddress^ addr)
			 {
				for(int index=0; index < onlineUsers->Length; index++)
				{
						if(onlineUsers[index]->IP == addr->ToString())
							return index;
				}

				return -1;
			 }
	private: System::Void rtbChat_TextChanged(System::Object^  sender, System::EventArgs^  e) {
			 rtbChat->ScrollToCaret();
		 }
};
}