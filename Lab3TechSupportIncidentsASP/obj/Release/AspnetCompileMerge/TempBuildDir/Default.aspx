<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lab3TechSupportIncidentsASP.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Technician Incidents</title>
    <style>

    /*//*************************************
    //SPORTS PRO INC. (Lab3)(ASP.NET)
    //WEBPAGE (DEFAULT) (HTML code)
    //Dean Jones
    //Jan.17, 2017
    //**************************************/

        .auto-style1 {
            width: 74px;
            height: 66px;
        }

    </style>
    <link href="Styles.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <header>SportsPro Inc.<br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <img alt="sports.jpg" class="auto-style1" longdesc="sports.jpg" src="images/Sports.jpg" /></header>
    <div>
        <h1>Technician Incidents&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; </h1>
    
        <h4>Technician Name:</h4>
&nbsp;<asp:DropDownList ID="ddlTechnician" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Name" DataValueField="TechID" Height="30px" Width="200px" AutoPostBack="True" Font-Size="Medium">
        </asp:DropDownList>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetAllTechnicians" TypeName="Lab3TechSupportIncidentsASP.App_Code.TechnicianDB"></asp:ObjectDataSource>
        <br />
        <h4>Incidents:</h4>
    
    </div>
        <asp:GridView ID="gvIncidents" runat="server" AutoGenerateColumns="False" CellPadding="6" DataSourceID="ObjectDataSource2" ForeColor="#333333" GridLines="None" HorizontalAlign="Left" CellSpacing="4" CssClass="gridview">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" BorderStyle="Solid" BorderWidth="1px" />
            <Columns>
                <asp:BoundField DataField="IncidentID" HeaderText="IncidentID" SortExpression="IncidentID" />
                <asp:BoundField DataField="Name" HeaderText="Customer" SortExpression="Name" />
                <asp:BoundField DataField="ProductCode" HeaderText="ProductCode" SortExpression="ProductCode" />
                <asp:BoundField DataField="TechID" HeaderText="TechID" SortExpression="TechID" />
                <asp:BoundField DataField="DateOpened" HeaderText="DateOpened" SortExpression="DateOpened" DataFormatString="{0:yyyy/MM/dd}" />
                <asp:BoundField DataField="DateClosed" HeaderText="DateClosed" SortExpression="DateClosed" DataFormatString="{0:yyyy/MM/dd}" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" BorderStyle="Inset" BorderWidth="1px" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetOpenTechIncidents" TypeName="Lab3TechSupportIncidentsASP.App_Code.IncidentDB">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlTechnician" Name="techID" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>      
    </form>
        <br />
    <footer>Lab3 ASP.NET - Dean Jones - Jan.16, 2017</footer>
</body>
</html>
