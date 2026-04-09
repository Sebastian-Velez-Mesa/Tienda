<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Clientes.aspx.cs" Inherits="examen_.Clientes" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="row g-4">
            <!-- Formulario Lateral -->
            <div class="col-lg-4">
                <div class="glass-card">
                    <h3 style="color: var(--accent); font-weight: 600; margin-bottom: 1.5rem;">
                        <i class="fas fa-user-plus me-2"></i>Nuevo Cliente
                    </h3>
                    <div class="form-group mb-3">
                        <label class="text-secondary small mb-1">Nombre Completo / Empresa</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ej: Juan Pérez">
                        </asp:TextBox>
                    </div>
                    <div class="form-group mb-3">
                        <label class="text-secondary small mb-1">Teléfono de Contacto</label>
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="+52 ...">
                        </asp:TextBox>
                    </div>
                    <div class="form-group mb-3">
                        <label class="text-secondary small mb-1">Correo Electrónico</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"
                            placeholder="correo@ejemplo.com"></asp:TextBox>
                    </div>
                    <div class="form-group mb-3">
                        <label class="text-secondary small mb-1">Dirección Física</label>
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"
                            placeholder="Calle, Ciudad..."></asp:TextBox>
                    </div>
                    <div class="mt-4">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cliente" OnClick="btnGuardar_Click"
                            CssClass="btn-premium w-100" />
                    </div>
                    <asp:Label ID="lblMensaje" runat="server" CssClass="mt-3 d-block small"></asp:Label>
                </div>
            </div>

            <!-- Tabla de Datos -->
            <div class="col-lg-8">
                <div class="glass-card h-100">
                    <h3 style="color: white; font-weight: 600; margin-bottom: 1.5rem;">
                        <i class="fas fa-address-book me-2"></i>Directorio de Clientes
                    </h3>
                    <div class="table-responsive">
                        <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="false" CssClass="modern-grid"
                            DataKeyNames="Id_Cliente" OnRowEditing="gvClientes_RowEditing"
                            OnRowDeleting="gvClientes_RowDeleting">
                            <Columns>
                                <asp:BoundField DataField="Id_Cliente" HeaderText="ID" ReadOnly="true" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                        <span style="color: var(--accent);">
                                            <%# Eval("Email") %>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                                <asp:TemplateField HeaderText="Acciones">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit"
                                            CssClass="btn btn-sm btn-outline-info me-1"><i class="fas fa-pen"></i>
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete"
                                            CssClass="btn btn-sm btn-outline-danger"
                                            OnClientClick="return confirm('¿Eliminar este cliente?');"><i
                                                class="fas fa-trash"></i></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </asp:Content>