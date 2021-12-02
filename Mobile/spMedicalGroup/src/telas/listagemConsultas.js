import React, { Component } from 'react';
import { FlatList, Image, ImageBackground, StyleSheet, Text, View } from 'react-native';

import api from '../services/api';
import { TouchableOpacity } from 'react-native-gesture-handler';




export default class Consultas extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaMeusEventos: [],
        };
    }



    //função logout
    //buscarConsultas


    render() {
        return (
            <View style={styles.container}>
                <View style={styles.container2} >
                    <ImageBackground source={require('../imagens/FundoLista.png')} style={styles.backgoundImage} >
                        <View style={styles.posicaoIcone}>
                            <TouchableOpacity onPress={this.logout}>
                                <Image source={require('../imagens/logout.png')} style={styles.logout} />
                            </TouchableOpacity>
                        </View>
                        <View style={styles.textoTitulo}>
                            <Text style={styles.h1}>Minhas Consultas</Text>
                        </View>
                    </ImageBackground>

                </View>
                <View style={styles.main}>
                    <View style={styles.card}>
                        <View  style={styles.espacoh2}>
                            <Text style={styles.h2}>Atendimento</Text>
                        </View>

                        <View style={styles.espacoCard}>
                            {/* <FlatList
                            contentContainerStyle={styles.mainBodyContent}
                            data={this.state.listaMeusEventos}
                            keyExtractor={item => item.idConsulta}
                            renderItem={this.renderItem}/> */}

                            {/* ---- */}

                            <View style={styles.conteudoAtendimento}>
                                <View>
                                    <Text style={styles.h3}>Médico</Text>
                                    <Text style={styles.pConsulta}>Roberto</Text>
                                </View>
                                <View>
                                    <Text style={styles.h3}>Clínica</Text>
                                    <Text style={styles.pConsulta}>Clínica SP</Text>
                                </View>
                                <View>
                                    <Text style={styles.h3}>Data e Hora</Text>
                                    <Text style={styles.pConsulta}>12/11/21 09:00</Text>
                                </View>
                                <View>
                                    <Text style={styles.h3}>Situação</Text>
                                    <Text style={styles.pConsulta}>Aguardando</Text>
                                </View>
                                <View>
                                    <Text style={styles.h3}>Descrição</Text>
                                    <Text style={styles.pConsulta}>...</Text>
                                </View>
                            </View>




                        </View>

                    </View>
                </View>
            </View>
        )
    }

    // renderItem = ({ item }) => (
    //    
    // )


}

const styles = StyleSheet.create({
    container: {
        flex: 1
    },

    container2: {
        flex: 0.35,
        //backgroundColor: 'black'
    },

    backgoundImage: {
        flex: 100,
        padding: 40,
        justifyContent: 'space-around'
    },

    posicaoIcone: {
        width: '100%',
        //marginTop: 20,
        alignItems: 'flex-end',
        //backgroundColor: 'red'
    },

    logout: {
        width: 25,
        height: 25
    },

    textoTitulo: {
        width: '100%',
        height: '100%',
        alignItems: 'center',
        justifyContent: 'center',
    },

    h1: {
        //backgroundColor: 'red',
        color: '#6D60F7',
        fontWeight: '700',
        //fontStyle: 'Poppins',
        fontSize: 40,
        fontFamily: "Poppins",
    },

    main: {
        backgroundColor: '#DEBFFF',
        flex: 0.65,
        alignItems: 'center',
        justifyContent: 'center'
    },

    card: {
        backgroundColor: '#FFF',
        height: '80%',
        width: '80%',
        borderRadius: 15,
        justifyContent: 'space-around',
        
    },

    espacoh2:{
        width: '100%',
        //backgroundColor: 'red',
        justifyContent: 'space-between',
        alignItems: 'center'
    },

    h2: {
        fontWeight: '500',
        fontSize: 20,
        color: '#6D60F7',
    },

    espacoCard: {
        width: '90%',
        height: '90%',
       // justifyContent: 'space-around',
    },

    conteudoAtendimento:{},

    h3: {
        color: '#6D60F7',
        fontSize: 18,
        fontWeight: '500'
    },

    pConsulta: {
        color: '#000',
        fontSize: 18,
        fontWeight: '500'
    },

})