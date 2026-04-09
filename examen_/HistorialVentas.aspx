<%@ Page Title="Historial de Ventas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="HistorialVentas.aspx.cs" Inherits="examen_.HistorialVentas" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="glass-card animate-fade-in">
            <h3 style="color: white; font-weight: 600; margin-bottom: 2rem;">
                <i class="fas fa-history me-2" style="color: #a18cd1;"></i>Registro Histórico de Ventas
            </h3>
            <div class="table-responsive">
                <asp:GridView ID="gvHistorial" runat="server" AutoGenerateColumns="true" CssClass="modern-grid">
                </asp:GridView>
            </div>
        </div>
    </asp:Content>