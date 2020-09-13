import React, { Component, useState, useEffect } from 'react';
import MaterialTable from 'material-table';
import axios from 'axios'

export default class Home extends Component {
  constructor(props){
    super(props)
    this.state = {
      columns: [
        { title: 'Name', field: 'name' },
        { title: 'Email', field: 'email' },
        { title: 'Gender', field: 'gender', lookup: { M: 'Male', F: 'Female' }, },
        { title: 'Married', field: 'is_married',lookup: { "true": 'Yes', "false": 'No' }, type: 'boolean'},
        { title: 'Address', field: 'address' },
      ],
      data: []
    }
  }

  componentDidMount = () => {
    this.fetchData()
  }

  fetchData = async () => {
    await axios.get(
      'https://localhost:44322/api/customer',
    ).then(response => {
      this.setState({data: response.data})
    })
  };

  addCustomer = async(newData) => {
    await fetch('https://localhost:44322/api/customer', {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(newData) 
    }).then(response => {
      this.fetchData()
    })
  }

  editCustomer = async(newData, oldData) => {
    await fetch('https://localhost:44322/api/customer?customerId=' + oldData.id, {
      method: "Put",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify(newData) 
    }).then(response => {
      this.fetchData()
    })
  }

  deleteCustomer = async(oldData) => {
    await fetch('https://localhost:44322/api/customer?customerId=' + oldData.id, {
      method: "Delete",
      headers: {
        "Content-Type": "application/json"
      },
    }).then(response => {
      this.fetchData()
    })
  }

  render(){
    return (
      <MaterialTable
        title="Customer Tabel"
        columns={this.state.columns}
        data={this.state.data}
        editable={{
          onRowAdd: (newData) =>
            new Promise((resolve) => {
              setTimeout(() => {
                resolve();
                this.addCustomer(newData)
              }, 600);
            }),
          onRowUpdate: (newData, oldData) =>
            new Promise((resolve) => {
              setTimeout(() => {
                resolve();
                if (oldData) {
                  this.editCustomer(newData, oldData)
                }
              }, 600);
            }),
          onRowDelete: (oldData) =>
            new Promise((resolve) => {
              setTimeout(() => {
                resolve();
                this.deleteCustomer(oldData)
              }, 600);
            }),
        }}
      />
    );
  }
}
