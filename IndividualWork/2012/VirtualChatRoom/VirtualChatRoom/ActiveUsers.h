using System::String;

enum modes {publicChat, privateChat, away, disconnect, Invite, Accept, Decline, PrivateChateTerminated};

public ref struct ActiveUsers
{
	String^ User;
	String^ IP;
	int mode;
};