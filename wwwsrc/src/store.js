import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let auth = Axios.create({
  baseURL: baseUrl + "account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    activeKeep: {},
    myKeeps: [],
    vaults: [],
    activeVault: {},
    vaultKeeps: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setKeeps(state, data) {
      state.keeps = data
    },
    setActiveKeep(state, data) {
      state.activeKeep = data
    },
    setMyKeeps(state, data) {
      state.myKeeps = data
    },
    setVaults(state, data) {
      state.vaults = data
    },
    setActiveVault(state, data) {
      state.activeVault = data
    },
    setVaultKeeps(state, data) {
      state.vaultKeeps = data
    }
  },
  actions: {
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logout({ commit, dispatch }) {
      auth.delete('logout')
        .then(res => {
          router.push({ name: 'login' })
          let data = {}
          commit('setUser', data)
        })
    },






    getKeeps({ commit, dispatch }) {
      api.get('keeps')
        .then(res => {
          commit('setKeeps', res.data)
        })
        .catch(e => {
          console.log('cant get keeps')
        })
    },
    getMyKeeps({ commit, dispatch }, uid) {
      api.get('keeps/' + uid, uid)
        .then(res => {
          commit('setMyKeeps', res.data)
        })
        .catch(e => {
          console.log('cant get keeps')
        })
    },
    createKeep({ commit, dispatch }, payload) {
      api.post('keeps', payload)
        .then(res => {
          dispatch('getKeeps')
        })
        .catch(e => {
          console.log('cant make keep')
        })
    },
    setActiveKeep({ commit, dispatch }, payload) {
      commit('setActiveKeep', payload)
    },
    deleteKeep({ commit, dispatch }, payload) {
      api.delete('keeps/' + payload.id)
        .then(res => {
          dispatch('getKeeps')
        })
        .catch(e => {
          console.log('cant delete keep')
        })
    },






    getVaults({ commit, dispatch }, uid) {
      api.get('vaults', uid)
        .then(res => {
          commit('setVaults', res.data)
        })
        .catch(e => {
          console.log('cant get vaults')
        })
    },
    createVault({ commit, dispatch }, payload) {
      api.post('vaults', payload)
        .then(res => {
          dispatch('getVaults')
        })
        .catch(e => {
          console.log('cant make vault')
        })
    },
    setActiveVault({ commit, dispatch }, payload) {
      commit('setActiveVault', payload)
      dispatch('getVaultKeeps', payload.id)
    },
    addToVault({ commit, dispatch }, payload) {
      api.post('vaults/' + payload.vaultId, payload)
        .then(res => {
          dispatch('getVaultKeeps', payload.vaultId)
        })
        .catch(e => {
          console.log('cant make vaultkeep')
        })
    },
    getVaultKeeps({ commit, dispatch }, vaultId) {
      api.get('vaults/' + vaultId + '/keeps')
        .then(res => {
          commit('setVaultKeeps', res.data)
        })
    },
    deleteVault({ commit, dispatch }, payload) {
      api.delete('vaults/' + payload.id)
        .then(res => {
          dispatch('getVaults')
        })
        .catch(e => {
          console.log('cant delete vault')
        })
    }
  }
})
