<%@ Page Title="Historial de Ventas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="HistorialVentas.aspx.cs" Inherits="examen_.HistorialVentas" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container mt-5 fade-in-up">
            <div class="glass-card">
                <h2>Historial de Ventas</h2>
                <div class="row">
                    <div class="col-md-12">
                        <asp:GridView ID="gvHistorial" runat="server" AutoGenerateColumns="true"
                            CssClass="table-custom mt-3"></asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </asp:Content>