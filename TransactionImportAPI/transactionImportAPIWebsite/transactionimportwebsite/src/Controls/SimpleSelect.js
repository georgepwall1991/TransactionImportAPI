import React from 'react';
import {makeStyles} from '@material-ui/core/styles';
import InputLabel from '@material-ui/core/InputLabel';
import MenuItem from '@material-ui/core/MenuItem';
import FormControl from '@material-ui/core/FormControl';
import Select from '@material-ui/core/Select';
import '../css/SimpleSelect.css';
import {TextField} from "@material-ui/core";

const useStyles = makeStyles((theme) => ({
    formControl: {
        margin: theme.spacing(1),
        minWidth: 120,
    },
    selectEmpty: {
        marginTop: theme.spacing(2),
    },
}));

export default function SimpleSelect() {
    const classes = useStyles();
    const [isoCode, setisoCode] = React.useState('');
    const [status, setStatus] = React.useState('');

    const handleChangeIsoCode = (event) => {
        setisoCode(event.target.value);
    }

    const handleChangeStatus = (event) => {
        setStatus(event.target.value)
    };

    return (
        <div id="inner">
            <FormControl required className={classes.formControl}>
                <InputLabel>ISO Code</InputLabel>
                <Select
                    labelId="currencyISOCode"
                    id="currencyId"
                    value={isoCode}
                    onChange={handleChangeIsoCode}>
                    <MenuItem value={"GBP"}>GBP</MenuItem>
                    <MenuItem value={"USD"}>USD</MenuItem>
                    <MenuItem value={"EUR"}>EUR</MenuItem>
                </Select>
            </FormControl>

            <FormControl required className={classes.formControl}>
                <InputLabel>Status</InputLabel>
                <Select
                    labelId="settlementStatusCode"
                    id="settlementStatusId"
                    value={status}
                    onChange={handleChangeStatus}>
                    <MenuItem value={"Settled"}>Settled</MenuItem>
                    <MenuItem value={"Instructed"}>Instructed</MenuItem>
                </Select>
            </FormControl>
            <br/>

            <TextField value="Transaction Amount"/>


        </div>
    );
}