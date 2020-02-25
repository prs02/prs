<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="container">

    <!-- Outer Row -->
    <div class="row justify-content-center">
      <div class="col-xl-10 col-lg-12 col-md-9"> 
       <div class="card o-hidden border-0 shadow-lg my-5">
          <div class="card-body p-0">
                <div class="p-5">
                  <div class="text-center">
                    <h1 class="h4 text-gray-900 mb-4">Forgot Password</h1>
                  </div>
                    <!-- insert a label and change the id: lblMessage. Ensure Text=""-->
                    <asp:Label ID="LblMessage" runat="server" Text=""></asp:Label>
                    <div class="form-group">
                        <!--change ID:txtEmail. Add placeholder="Enter email address". TextMode: Email  -->

                        <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter Email Address" class="form-control form-control-user" TextMode="Email"></asp:TextBox>
                    </div>
                        <!--change ID:BtnSubmit. Text: Submit  -->
                        <asp:Button ID="BtnSubmit" runat="server" Text="Submit" class="btn btn-primary btn-user btn-block" OnClick="BtnSubmit_Click" />
                  </div>
                  <hr>
                  <div class="text-center">
                    <a class="small" href="Login.aspx">Login</a>
                  </div> 
              </div>
            </div>
          </div>
        </div>
      </div>



</asp:Content>

