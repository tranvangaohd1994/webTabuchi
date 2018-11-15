<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewPlan.aspx.cs" Inherits="Website.AddNewPlan" MaintainScrollPositionOnPostback="true" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" href="layout/styles/layout.css" type="text/css" />
    <title>Input form day </title>
    <%-- fixed Header Gridview with multi header  --%>
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="js/gridviewScroll.js"></script>
    <link href="layout/styles/GridviewScroll.css" rel="stylesheet" />

    <%-- 
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
--%>
    <link rel="stylesheet" href="js/jquery-ui.css" />
    <script type="text/javascript">
        function button_click(objTextBox, objBtnID) {
            if (window.event.keyCode == 13) {
                document.getElementById(objBtnID).focus();
                document.getElementById(objBtnID).click();
            }
        }
        $(function () {
            $("#datepicker").datepicker({
                dateFormat: 'dd/mm/yy',
                minDate: 0,
            });

            $(".ui-datepicker-trigger").mouseover(function () {
                $(this).css('cursor', 'pointer');
            });
        });
        function time() {
            var today = new Date();
            var weekday = new Array(7);
            weekday[0] = "Sunday";
            weekday[1] = "Monday";
            weekday[2] = "Tuesday";
            weekday[3] = "Wednesday";
            weekday[4] = "Thursday";
            weekday[5] = "Friday";
            weekday[6] = "Saturday";
            var day = weekday[today.getDay()];
            var dd = today.getDate();
            var mm = today.getMonth() + 1; //January is 0!
            var yyyy = today.getFullYear();
            var h = today.getHours();
            var m = today.getMinutes();
            var s = today.getSeconds();
            m = checkTime(m);
            s = checkTime(s);
            nowTime = h + ":" + m + ":" + s;
            if (dd < 10) { dd = '0' + dd } if (mm < 10) { mm = '0' + mm } today = day + ', ' + dd + '/' + mm + '/' + yyyy;

            tmp = '<span class="date">' + today + ' | ' + nowTime + '</span>';

            document.getElementById("clock").innerHTML = tmp;

            clocktime = setTimeout("time()", "1000", "JavaScript");
            function checkTime(i) {
                if (i < 10) {
                    i = "0" + i;
                }
                return i;
            }

            $(function () {
                $("#datepicker").datepicker({
                    dateFormat: 'dd/mm/yy',
                    minDate: 0,
                });

                $(".ui-datepicker-trigger").mouseover(function () {
                    $(this).css('cursor', 'pointer');
                });
            });
        }
    </script>
</head>
<body onload="time()" style="background-color: white">
    <form id="form1" runat="server">
        <div class="wrapper col2">
            <div id="topbar">
                <div id="topnav">
                    <ul>
                        <li>
                            <asp:LinkButton runat="server" ID="lbtnHome" OnClick="lbtnHome_Click">Home Page</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton runat="server" ID="lblControl" Height="30px">Control</asp:LinkButton>
                            <ul>
                                <li><a href="AddNewModel.aspx">Add Item</a></li>
                                <li><a href="ChangePassword.aspx">Change password</a></li>
                            </ul>
                        </li>

                        <li>
                            <asp:LinkButton runat="server" ID="lbtnExport" OnClick="lbtnExport_Click">Export Excel</asp:LinkButton></li> 
                    </ul>
                </div>
                <div id="search">
                    <fieldset>
                        <legend>Date Time</legend>
                        <div id="clock" style="margin-top: 10px"></div>
                    </fieldset>
                </div>
                <br class="clear" />
            </div>
            
        </div>
        
        <div style="margin-top: 5px;">
            <div style="width: 30%; margin-left: 20%; float: left">
                <div>
                    <asp:TextBox ID="datepicker" runat="server"></asp:TextBox>
                    <asp:Button ID="btnView" runat="server" Text="Show" OnClick="btnView_Click" />
                </div>
                <div style="margin-top: 4px">
                    <asp:Button ID="btnCreate"  runat="server" Text="Create" OnClick="btnCreate_Click" Visible="false"/>
                    <asp:Label ID="lblAlart" runat="server" style="color: #333;" ></asp:Label> 
                </div>
            </div>
            <div style="margin-left: 20%;">
                <asp:DropDownList runat="server" ID="ddlShift" Width="140px" BorderWidth="1px" OnSelectedIndexChanged="ddlShift_SelectedIndexChanged" AutoPostBack="True" Visible ="false">
                    <asp:ListItem Value="Day" Selected="True">Work Shift : Day</asp:ListItem>
                    <asp:ListItem Value="Night">Work Shift : Night</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        
            
           
        <div id="content" style="width: 100%;  color: black; height: 500px; margin-left: 2px; margin-top: 10px">
            
            <asp:ScriptManager ID="ScriptManager1" runat="server"
                EnablePageMethods="true">
            </asp:ScriptManager>
            <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="False" BorderColor="#CCCCCC" ForeColor="Black" Width="1100px" OnRowCreated="GridView1_RowCreated" ShowHeader="false" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" CellPadding="0" CellSpacing="2" Visible="false">
                <HeaderStyle HorizontalAlign="Center" Font-Size="Small" />
                <AlternatingRowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:BoundField DataField="LineName" HeaderText="L" ItemStyle-Width="25px">
                        <ItemStyle Width="23px" HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="ModelA">
                        <ItemTemplate>
                            <div style="width: 100px; float: left; margin-left: 0px">
                                <asp:TextBox ID="TextBoxMDA" runat="server" Width="72px" Enabled="false" Text='<%# Bind("ModelA") %>' onFocus="this.select()"></asp:TextBox>
                                <asp:RadioButton ID="rdModelA" runat="server" Enabled="false" GroupName="Model" Width="5px" />
                                <cc1:AutoCompleteExtender ServiceMethod="SearchCustomers"
                                    MinimumPrefixLength="1"
                                    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                                    TargetControlID="TextBoxMDA"
                                    ID="AutoCompleteExtender1" runat="server" FirstRowSelected="false">
                                </cc1:AutoCompleteExtender>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ModelB">
                        <ItemTemplate>
                            <div style="width: 100px; float: left; margin-left: 0px">
                                <asp:TextBox ID="TextBoxMDB" runat="server" Width="72px" Enabled="false" Text='<%# Bind("ModelB") %>' onFocus="this.select()"></asp:TextBox>
                                <asp:RadioButton ID="rdModelB" runat="server" Enabled="false" GroupName="Model" Width="5px" />
                                <cc1:AutoCompleteExtender ServiceMethod="SearchCustomers"
                                    MinimumPrefixLength="1"
                                    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                                    TargetControlID="TextBoxMDB"
                                    ID="AutoCompleteExtender2" runat="server" FirstRowSelected="false">
                                </cc1:AutoCompleteExtender>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ModelC">
                        <ItemTemplate>
                            <div style="width: 100px; float: left; margin-left: 0px">
                                <asp:TextBox ID="TextBoxMDC" runat="server" Width="72px" Enabled="false" Text='<%# Bind("ModelC") %>' onFocus="this.select()"></asp:TextBox>
                                <asp:RadioButton ID="rdModelC" runat="server" Enabled="false" GroupName="Model" Width="5px" />
                                <cc1:AutoCompleteExtender ServiceMethod="SearchCustomers"
                                    MinimumPrefixLength="1"
                                    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
                                    TargetControlID="TextBoxMDC"
                                    ID="AutoCompleteExtender3" runat="server" FirstRowSelected="false">
                                </cc1:AutoCompleteExtender>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="R/S">
                        <ItemTemplate>
                            <div>
                                <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" Checked='<%#bool.Parse(Eval("[RS]").ToString())%>' OnCheckedChanged="chkAll_CheckedChanged" />
                            </div>
                        </ItemTemplate>
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Planed Worker">
                        <ItemTemplate>
                            <asp:Label ID="LabelPW" runat="server" Width="30px" Text='<%# Bind("Planed_Worker") %>'></asp:Label>
                            <asp:TextBox ID="TextBoxPW" runat="server" Width="25px" MaxLength="2" Text='<%# Bind("Planed_Worker") %>' Visible="false"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText=" Actual Worker ">
                        <ItemTemplate>
                            <asp:Label ID="LabelAW" runat="server" Width="30" Text='<%# Bind("Actual_Worker") %>'></asp:Label>
                            <asp:TextBox ID="TextBoxAW" runat="server" Width="25px" MaxLength="2" Text='<%# Bind("Actual_Worker") %>' Visible="false"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Plan">
                        <ItemTemplate>
                            <asp:Label ID="LabelPl" runat="server" Width="35px" Text='<%# Bind("Plan") %>'></asp:Label>
                            <asp:TextBox ID="TextBoxPl" runat="server" Width="32px" Text='<%# Bind("Plan") %>' Visible="false"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Tact Time">
                        <ItemTemplate>
                            <asp:Label ID="LabelTT" runat="server" Width="43px" Text='<%# Bind("Tact_Time","{0:0.#}") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="45px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Total Minute">
                        <ItemTemplate>
                            <asp:Label ID="LabelTM" runat="server" Width="45px" Text='<%# Bind("Total_Minute") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="45px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="From1">
                        <ItemTemplate>
                            <asp:Label ID="LabelF1" runat="server" Width="40px" Text='<%# Bind("From1") %>'></asp:Label>
                            <asp:TextBox ID="TextBoxF11" runat="server" Width="20px" MaxLength="2" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBoxF12" runat="server" Width="20px" MaxLength="2" Visible="false"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="To1">
                        <ItemTemplate>
                            <asp:Label ID="LabelT1" runat="server" Width="40px" Text='<%# Bind("To1") %>'></asp:Label>
                            <asp:TextBox ID="TextBoxT11" runat="server" Width="20px" MaxLength="2" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBoxT12" runat="server" Width="20px" MaxLength="2" Visible="false"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="From2">
                        <ItemTemplate>
                            <asp:Label ID="LabelF2" runat="server" Width="40px" Text='<%# Bind("From2") %>'></asp:Label>
                            <asp:TextBox ID="TextBoxF21" runat="server" Width="20px" MaxLength="2" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBoxF22" runat="server" Width="20px" MaxLength="2" Visible="false"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="To2">
                        <ItemTemplate>
                            <asp:Label ID="LabelT2" runat="server" Width="40px" Text='<%# Bind("To2") %>'></asp:Label>
                            <asp:TextBox ID="TextBoxT21" runat="server" Width="20px" MaxLength="2" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBoxT22" runat="server" Width="20px" MaxLength="2" Visible="false"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="From3">
                        <ItemTemplate>
                            <asp:Label ID="LabelF3" runat="server" Width="40px" Text='<%# Bind("From3") %>'></asp:Label>
                            <asp:TextBox ID="TextBoxF31" runat="server" Width="20px" MaxLength="2" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBoxF32" runat="server" Width="20px" MaxLength="2" Visible="false"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="To3">
                        <ItemTemplate>
                            <asp:Label ID="LabelT3" runat="server" Width="40px" Text='<%# Bind("To3") %>'></asp:Label>
                            <asp:TextBox ID="TextBoxT31" runat="server" Width="20px" MaxLength="2" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBoxT32" runat="server" Width="20px" MaxLength="2" Visible="false"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="From4">
                        <ItemTemplate>
                            <asp:Label ID="LabelF4" runat="server" Width="40px" Text='<%# Bind("From4") %>'></asp:Label>
                            <asp:TextBox ID="TextBoxF41" runat="server" Width="20px" MaxLength="2" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBoxF42" runat="server" Width="20px" MaxLength="2" Visible="false"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="To4">
                        <ItemTemplate>
                            <asp:Label ID="LabelT4" runat="server" Width="40px" Text='<%# Bind("To4") %>'></asp:Label>
                            <asp:TextBox ID="TextBoxT41" runat="server" Width="20px" MaxLength="2" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBoxT42" runat="server" Width="20px" MaxLength="2" Visible="false"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="From5">
                        <ItemTemplate>
                            <asp:Label ID="LabelF5" runat="server" Width="40px" Text='<%# Bind("From5") %>'></asp:Label>
                            <asp:TextBox ID="TextBoxF51" runat="server" Width="20px" MaxLength="2" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBoxF52" runat="server" Width="20px" MaxLength="2" Visible="false"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="To5">
                        <ItemTemplate>
                            <asp:Label ID="LabelT5" runat="server" Width="40px" Text='<%# Bind("To5") %>'></asp:Label>
                            <asp:TextBox ID="TextBoxT51" runat="server" Width="20px" MaxLength="2" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBoxT52" runat="server" Width="20px" MaxLength="2" Visible="false"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="From6">
                        <ItemTemplate>
                            <asp:Label ID="LabelF6" runat="server" Width="30px" Text='<%# Bind("From6") %>'></asp:Label>
                            <asp:TextBox ID="TextBoxF61" runat="server" Width="20px" MaxLength="2" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBoxF62" runat="server" Width="20px" MaxLength="2" Visible="false"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="To6">
                        <ItemTemplate>
                            <asp:Label ID="LabelT6" runat="server" Width="40px" Text='<%# Bind("To6") %>'></asp:Label>
                            <asp:TextBox ID="TextBoxT61" runat="server" Width="20px" MaxLength="2" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="TextBoxT62" runat="server" Width="20px" MaxLength="2" Visible="false"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40px"/>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cmts">
                        <ItemTemplate>
                            <asp:Label ID="LabelCM" runat="server" Width="40px" Text='<%# Bind("Comments") %>'></asp:Label>
                            <asp:TextBox ID="TextBoxCM" runat="server" Width="38px" Text='<%# Bind("Comments") %>' Visible="false"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Rank">
                        <ItemTemplate>
                            <asp:Label ID="LabelRank" runat="server" Width="35px" Text='<%# Bind("Rank") %>'></asp:Label>
                            <asp:TextBox ID="TextBoxRank" runat="server" Width="30px" MaxLength="1" Text='<%# Bind("Rank") %>' Visible="false"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Control">
                        <ItemTemplate>
                            <asp:ImageButton runat="server" ID="btnSave" ImageUrl="~/image/icon-save.png" ToolTip="Save" OnClick="btnSave_Click" Visible="false" Width="25px" Height="16px" />
                            <asp:ImageButton runat="server" ID="btnBack" ImageUrl="~/image/icon-return.png" ToolTip="Back" OnClick="btnBack_Click" Visible="false" Width="25px" Height="14px" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
        </div>
        <br class="clear" />
    </form>

    <script type="text/javascript">
        $(document).ready(function () {
            gridviewScroll();
        });

        function gridviewScroll() {
            gridView1 = $('#GridView1').gridviewScroll({
                width: 1260,
                height: $(window).height() - 100,
                railcolor: "#F0F0F0",
                barcolor: "#CDCDCD",
                barhovercolor: "#606060",
                bgcolor: "#F0F0F0",
                freezesize: 1,
                headerrowcount: 2,
                railsize: 16,
                barsize: 12
            });
        }
	</script>
</body>
</html>
