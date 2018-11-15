<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangeActualInputDay.aspx.cs" Inherits="Website.ChangeActualInputDay" EnableEventValidation="false" MaintainScrollPositionOnPostback="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Change Actual by Hour</title>
    <link rel="stylesheet" href="../layout/styles/layout.css" type="text/css" />
     <script type="text/javascript" src="js/jquery.min.js"></script>
     <style type="text/css">    
        .hover_row
        {
            background-color: #FFFFBF;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("[id*=GridView1] td").hover(function () {
                $("td", $(this).closest("tr")).addClass("hover_row");
            }, function () {
                $("td", $(this).closest("tr")).removeClass("hover_row");
            });
        });
    </script>
    <script type="text/javascript">
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
                            <asp:LinkButton runat="server" ID="lbtHome" Width="70px" OnClick="lbtHome_Click" CausesValidation="false" >Home</asp:LinkButton></li>
                        <li>
                            <asp:LinkButton runat="server" ID="lbtInputForm" Width="70px" OnClick="lbtInputForm_Click" CausesValidation="false" >Input Page</asp:LinkButton></li>
                        <li>
                            <asp:DropDownList runat="server" ID="ddlShift" Width="140px" CssClass="ddlShift" BorderWidth="1px" BackColor="#0291d0" ForeColor="White" Height="25px" OnSelectedIndexChanged="ddlShift_SelectedIndexChanged" AutoPostBack="True" Font-Bold="true">
                                <asp:ListItem Value="Day" Selected="True">Work Shift : Day</asp:ListItem>
                                <asp:ListItem Value="Night">Work Shift : Night</asp:ListItem>
                            </asp:DropDownList>
                        </li>
                    </ul>
                </div>
                <div id="search">
                    <fieldset>
                        <legend>Date Time</legend>
                        <div id="clock" style="width: 200px"></div>
                    </fieldset>

                </div>
                <br class="clear" />
            </div>
        </div>

        <div id="content" style="width: 100%; color: black; height: 1000px">
            <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" style="margin-left: 50px"  >
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderColor="#333333" OnRowDataBound="GridView1_RowDataBound" ShowFooter="true" CellSpacing="2" Font-Size="11" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <HeaderStyle HorizontalAlign="Center" Font-Size="Smaller" Height="30px" BackColor="#EFEFEF" />
                    <FooterStyle BackColor="White" ForeColor="#000099" HorizontalAlign="Center" Font-Bold="true" />
                    <Columns>
                        <asp:BoundField DataField="LineName" HeaderText="Line">
                            <ItemStyle Width="40px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="Rank" HeaderText="Rank">
                            <ItemStyle Width="40px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField HeaderText="Model" DataField="Model">
                            <ItemStyle Width="140px" HorizontalAlign="Left" Font-Size="Smaller"></ItemStyle>
                        </asp:BoundField>

                        <asp:BoundField DataField="ChangeModel" HeaderText="C.M">
                            <ItemStyle Width="40px" HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Plan" DataField="Plan">
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Actual" DataField="Actual">
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Diff" DataField="Diff">
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Target" DataField="Target">
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="A.R">
                            <ItemTemplate>
                                <asp:Label ID="lblArchived_Rate" runat="server" Width="35px" Text='<%# Eval("Archived_Rate") +"%" %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="37px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="07H">
                            <ItemTemplate>
                                <asp:Label ID="lbl07H" runat="server" Width="40px" Text='<%# Bind("H07") %>'></asp:Label>
                                <asp:TextBox ID="txt07H" runat="server" Width="40px" Text='<%# Bind("H07") %>' Visible="false"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="08H">
                            <ItemTemplate>
                                <asp:Label ID="lbl08H" runat="server" Width="40px" Text='<%# Bind("H08") %>'></asp:Label>
                                <asp:TextBox ID="txt08H" runat="server" Width="40px" Text='<%# Bind("H08") %>' Visible="false"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="09H">
                            <ItemTemplate>
                                <asp:Label ID="lbl09H" runat="server" Width="40px" Text='<%# Bind("H09") %>'></asp:Label>
                                <asp:TextBox ID="txt09H" runat="server" Width="40px" Text='<%# Bind("H09") %>' Visible="false"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="10H">
                            <ItemTemplate>
                                <asp:Label ID="lbl10H" runat="server" Width="40px" Text='<%# Bind("H10") %>'></asp:Label>
                                <asp:TextBox ID="txt10H" runat="server" Width="40px" Text='<%# Bind("H10") %>' Visible="false"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="11H">
                            <ItemTemplate>
                                <asp:Label ID="lbl11H" runat="server" Width="40px" Text='<%# Bind("H11") %>'></asp:Label>
                                <asp:TextBox ID="txt11H" runat="server" Width="40px" Text='<%# Bind("H11") %>' Visible="false"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="12H">
                            <ItemTemplate>
                                <asp:Label ID="lbl12H" runat="server" Width="40px" Text='<%# Bind("H12") %>'></asp:Label>
                                <asp:TextBox ID="txt12H" runat="server" Width="40px" Text='<%# Bind("H12") %>' Visible="false"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="13H">
                            <ItemTemplate>
                                <asp:Label ID="lbl13H" runat="server" Width="40px" Text='<%# Bind("H13") %>'></asp:Label>
                                <asp:TextBox ID="txt13H" runat="server" Width="40px" Text='<%# Bind("H13") %>' Visible="false"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="14H">
                            <ItemTemplate>
                                <asp:Label ID="lbl14H" runat="server" Width="40px" Text='<%# Bind("H14") %>'></asp:Label>
                                <asp:TextBox ID="txt14H" runat="server" Width="40px" Text='<%# Bind("H14") %>' Visible="false"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="15H">
                            <ItemTemplate>
                                <asp:Label ID="lbl15H" runat="server" Width="40px" Text='<%# Bind("H15") %>'></asp:Label>
                                <asp:TextBox ID="txt15H" runat="server" Width="40px" Text='<%# Bind("H15") %>' Visible="false"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="16H">
                            <ItemTemplate>
                                <asp:Label ID="lbl16H" runat="server" Width="40px" Text='<%# Bind("H16") %>'></asp:Label>
                                <asp:TextBox ID="txt16H" runat="server" Width="40px" Text='<%# Bind("H16") %>' Visible="false"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="17H">
                            <ItemTemplate>
                                <asp:Label ID="lbl17H" runat="server" Width="40px" Text='<%# Bind("H17") %>'></asp:Label>
                                <asp:TextBox ID="txt17H" runat="server" Width="40px" Text='<%# Bind("H17") %>' Visible="false"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="18H">
                            <ItemTemplate>
                                <asp:Label ID="lbl18H" runat="server" Width="40px" Text='<%# Bind("H18") %>'></asp:Label>
                                <asp:TextBox ID="txt18H" runat="server" Width="40px" Text='<%# Bind("H18") %>' Visible="false"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="45px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Status" DataField="Status">
                            <ItemStyle HorizontalAlign="Center" Width="45px" Font-Bold="true" />
                        </asp:BoundField>
                            <asp:TemplateField HeaderText="Control">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="btnSave" ImageUrl="~/image/icon-save.png" ToolTip="Save" OnClick="btnSave_Click" Visible="false" Width="25px" Height="16px" />
                                <asp:ImageButton runat="server" ID="btnBack" ImageUrl="~/image/icon-return.png" ToolTip="Back" OnClick="btnBack_Click" Visible="false" Width="25px" Height="14px" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="30" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
         </div>
    </form>
</body>
</html>
