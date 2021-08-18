import {Button} from '@material-ui/core';
import './App.css';
import '@fontsource/roboto';
import SimpleSelect from "./Controls/SimpleSelect";

function App() {
    return (
        <div>
            <div className="flexbox-container">
                <SimpleSelect/>
                <br/>
                <br/>
                <br/>

                <Button variant="outlined" color="secondary" onClick={() => alert("Imported Transactions Succesfully")}>
                    Import API Transactions
                </Button>
            </div>
        </div>
    )
}

export default App;
