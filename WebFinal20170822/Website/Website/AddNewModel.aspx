<%@ Page Title="" Language="C#" MasterPageFile="~/Master Page/Site1.Master" AutoEventWireup="true" CodeBehind="AddNewModel.aspx.cs" Inherits="Website.AddNewModel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="pnlHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pnlContent" runat="server">
    <div>
        <p></p>
        <p></p>
        <h2 style="width: 600px; margin-left: 200px">Add New Model</h2>      
        <p></p>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        <div style="margin-left:20%">
            <asp:ValidationSummary ID="ValidationSumary" runat="server" ShowSummary="true" />
            <asp:Label runat="server" ID="lblNameProduct" Text="Name Model:" Font-Size="Medium" Width="170px" />
            <asp:TextBox runat="server" ID="txtName" Width="170px"></asp:TextBox>
            <cc1:AutoCompleteExtender ServiceMethod="SearchCustomers"
                MinimumPrefixLength="1"
                CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                TargetControlID="txtName"
                ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
            </cc1:AutoCompleteExtender>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorNameModel" runat="server" ControlToValidate="txtName" ErrorMessage="Name model must be 5-30 character, no blank" ValidationExpression="[^\s]{5,30}" Display="None" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ControlToValidate="txtName" ErrorMessage="Name model is no null" Display="None"></asp:RequiredFieldValidator>
            <p></p>
            <div style="margin-left: 190px">
                <asp:ImageButton runat="server" ID="btnSave" ImageUrl="~/image/1435843633_save.png" ToolTip="Save" OnClick="btnSave_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton runat="server" ID="btnReset" ImageUrl="~/image/1435843678_refresh.png" ToolTip="Reset" OnClick="btnReset_Click" CausesValidation="False" />
            </div>
        </div>
    </div>
</asp:Content>
