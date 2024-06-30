import './App.css'
import { MsalProvider } from "@azure/msal-react";
import { IPublicClientApplication } from "@azure/msal-browser";
import { AuthenticatedTemplate, UnauthenticatedTemplate } from "@azure/msal-react";
import { ExampleComponent } from "./components/ExampleComponent";
import { useMsal } from "@azure/msal-react";
import { useAuth } from "./services/AuthService";


type AppProps = {
  pca: IPublicClientApplication;
};

const App: React.FC<AppProps> = ({ pca }) => {

    const { logIn, logOut } = useAuth();
    const { accounts } = useMsal();


  return (
    <MsalProvider instance={pca}>
      <div>
        <h1>My App</h1>
        <AuthenticatedTemplate>
          <p>Welcome, {accounts[0]?.name}</p>
          <button onClick={logOut}>Logout</button>
          <ExampleComponent />
        </AuthenticatedTemplate>
        <UnauthenticatedTemplate>
          <button onClick={logIn}>Login</button>
        </UnauthenticatedTemplate>
      </div>
    </MsalProvider>
  );
};

export default App;
