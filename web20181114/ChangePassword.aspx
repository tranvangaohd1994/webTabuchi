<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page/Site1.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Website.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pnlHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pnlContent" runat="server">
    <p></p>
    <p></p>
    <h2 style="width: 600px; margin-left: 200px">Change Password</h2>
    <p></p>
    <div style="margin-left: 20%">
        <asp:ValidationSummary ID="ValidationSumary" runat="server" ShowSummary="true" />
        <asp:Label runat="server" ID="lblOldPass" Text="Old Password:" Font-Size="12" Width="170px" />
        <asp:TextBox runat="server" TextMode="Password" ID="txtOldPass" Width="200px"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorOldPass" runat="server" ControlToValidate="txtOldPass" ErrorMessage="Old password must be 5-12 character, no blank" ValidationExpression="[^\s]{5,12}" Display="None" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="txtOldPass" ErrorMessage="Old password is not null" Display="None"></asp:RequiredFieldValidator>
        <p></p>
        <br />
        <asp:Label runat="server" ID="lblNewPassword" Text="New password:" Font-Size="12" Width="170px"  />
        <asp:TextBox runat="server" TextMode="Password" ID="txtNewPass" Width="200px"></asp:TextBox><br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorNewPass" runat="server" ControlToValidate="txtNewPass" ErrorMessage="New password must be 5-12 character, no blank" ValidationExpression="[^\s]{5,12}" Display="None" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNewPass" ErrorMessage="New password is not null" Display="None"></asp:RequiredFieldValidator>
        <p></p>
        <asp:Label runat="server" ID="lblConfirm" Text="Confirm new password:" Font-Size="12" Width="170px"  />
        <asp:TextBox runat="server" TextMode="Password" ID="txtConfirm" Width="200px"></asp:TextBox>
        <asp:CompareValidator runat="server" ID="CompareValidatorConfirm" ControlToValidate="txtConfirm" ControlToCompare="txtNewPass" Type="String" Operator="Equal" ErrorMessage="Fail confirm password, try again" Display="None"></asp:CompareValidator>
        <p></p>
        <div style="margin-left: 190px">
            <asp:ImageButton runat="server" ID="btnSave" ImageUrl="~/image/1435843633_save.png" ToolTip="Save" OnClick="btnSave_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ImageButton runat="server" ID="btnReset" ImageUrl="~/image/1435843678_refresh.png" ToolTip="Reset" OnClick="btnReset_Click" CausesValidation="False" />
        </div>
    </div>
</asp:Content>
